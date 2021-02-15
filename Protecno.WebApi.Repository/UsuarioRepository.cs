using Dapper;
using Protecno.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Protecno.WebApi.Repository
{
    public class UsuarioRepository : IDisposable
    {
        SqlConnection conn;
        public UsuarioRepository()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Context"].ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public Usuario GetUsuarioLogin(string email, string senha)
        {
            var usuario = GetUsuarioPorEmail(email);

            if (usuario != null)
            {
                if (usuario.Senha.Equals(senha) && usuario.Email.Equals(email))
                {
                    return usuario;
                }
            }
            return new Usuario();
        }

        public Usuario GetUsuarioPorEmail(string email)
        {
            var sql = @"select * from Inventarios.Usuarios where email = @email";

            return conn.Query<Usuario>(sql, commandType: CommandType.Text).ToList().FirstOrDefault();
        }

        public List<Usuario> GetUsuarios(string filtro, string ordem)
        {
            string sql = @"  SELECT U.* FROM Inventarios.Usuarios U " + filtro + " " + ordem;

            return conn.Query<Usuario>(sql, commandType: CommandType.Text).ToList();
        }

        public List<Usuario> GetUsuarios(string filtro, string ordem, SqlConnection conn, SqlTransaction tran)
        {
            List<Usuario> list = new List<Usuario>();

            string sql = @" SELECT U.* FROM Inventarios.Usuarios U " + filtro + " " + ordem;

            list = conn.Query<Usuario>(sql, CommandType.Text, tran).ToList();

            return list;
        }

        public int GravarUsuarios(Usuario obj, SqlConnection conn, SqlTransaction tran)
        { 
            string sqlQuery = "";
            if (obj.Id == 0)
            {
                #region INSERT
                sqlQuery = @" INSERT INTO [Inventarios].[Usuarios]
                                            ([NomeCompleto]
                                            ,[Email]
                                            ,[Telefone]
                                            ,[Senha]                                       
                                            ,[SolicitaAlteracaoDeSenha]
                                            ,[EmailValido]
                                            ,[DataCadastro]
                                            ,[Ativo]
                                            ,[DataAtualizacao] 
                                            ,[EmpresasId]
                                            ,[PermiteOperacaoesEmUsuarios  ]
                                            ,[PermiteOperacoesEmInventarios]
                                            ,[PermiteOperacoesEmCadastros  ]
                                            ,[PermiteAlterarConfiguracoes  ] )
                                        VALUES
                                            (@NomeCompleto
                                            ,@Email
                                            ,@Telefone
                                            ,@Senha                                             
                                            ,@SolicitaAlteracaoDeSenha
                                            ,@EmailValido
                                            ,@DataCadastro
                                            ,@Ativo
                                            ,@DataAtualizacao 
                                            ,@EmpresasId
                                            ,@PermiteOperacaoesEmUsuarios  
                                            ,@PermiteOperacoesEmInventarios
                                            ,@PermiteOperacoesEmCadastros  
                                            ,@PermiteAlterarConfiguracoes )";
                #endregion
            }
            else
            {
                #region UPDATE 
                sqlQuery = @"  UPDATE [Inventarios].[Usuarios]
                                    SET  [NomeCompleto] = @NomeCompleto 
                                        ,[Email] = @Email
                                        ,[Telefone] = @Telefone 
                                        ,[Senha] = @Senha 
                                         
                                        ,[SolicitaAlteracaoDeSenha] = @SolicitaAlteracaoDeSenha 
                                        ,[EmailValido] = @EmailValido 
                                        ,[DataCadastro] = @DataCadastro 
                                        ,[Ativo] = @Ativo 
                                        ,[DataAtualizacao] = @DataAtualizacao  
                                        ,[EmpresasId] = @EmpresasId 
                                        ,[PermiteOperacaoesEmUsuarios] = @PermiteOperacaoesEmUsuarios   
                                        ,[PermiteOperacoesEmInventarios] = @PermiteOperacoesEmInventarios 
                                        ,[PermiteOperacoesEmCadastros] = @PermiteOperacoesEmCadastros   
                                        ,[PermiteAlterarConfiguracoes] = @PermiteAlterarConfiguracoes   
                                    WHERE Id = @Id";
                #endregion
            }

            using (SqlCommand dataCommand = new SqlCommand(sqlQuery, conn))
            {
                dataCommand.Transaction = tran;

                dataCommand.Parameters.AddWithValue("@NomeCompleto", obj.NomeCompleto);
                dataCommand.Parameters.AddWithValue("@Email", obj.Email);
                dataCommand.Parameters.AddWithValue("@Telefone", obj.Telefone);
                dataCommand.Parameters.AddWithValue("@Senha", obj.Senha);
                dataCommand.Parameters.AddWithValue("@SolicitaAlteracaoDeSenha", obj.SolicitaAlteracaoDeSenha);
                dataCommand.Parameters.AddWithValue("@EmailValido", obj.EmailValido);
                dataCommand.Parameters.AddWithValue("@DataCadastro", obj.DataCadastro);
                dataCommand.Parameters.AddWithValue("@Ativo", obj.Ativo);
                dataCommand.Parameters.AddWithValue("@DataAtualizacao", obj.DataAtualizacao);
                dataCommand.Parameters.AddWithValue("@EmpresasId", obj.Empresa.Id);
                dataCommand.Parameters.AddWithValue("@PermiteOperacaoesEmUsuarios", obj.PermiteOperacaoesEmUsuarios);
                dataCommand.Parameters.AddWithValue("@PermiteOperacoesEmInventarios", obj.PermiteOperacoesEmInventarios);
                dataCommand.Parameters.AddWithValue("@PermiteOperacoesEmCadastros", obj.PermiteOperacoesEmCadastros);
                dataCommand.Parameters.AddWithValue("@PermiteAlterarConfiguracoes", obj.PermiteAlterarConfiguracoes);

                if (obj.Id > 0)
                    dataCommand.Parameters.AddWithValue("@Id", obj.Id);

                return dataCommand.ExecuteNonQuery();
            }  
        }

        public int ExcluirUsuarios(Usuario obj)
        {
            int retorno;
            string sqlQuery = @" UPDATE [Inventarios].[Usuarios] SET ATIVO = 0 WHERE Id = @Id";

            using (SqlCommand dataCommand = new SqlCommand(sqlQuery, conn))
            {
                dataCommand.Parameters.AddWithValue("@Id", obj.Id);

                retorno = dataCommand.ExecuteNonQuery();
            }

            return retorno;
        }


        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    conn.Close();
                    conn.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
