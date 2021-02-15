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
    public class FilialRepository : IDisposable
    {
        SqlConnection conn;
        public FilialRepository()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Context"].ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }

        public List<Filial> GetFiliais(string filtro, string ordem)
        {
            string sql = @" SELECT  F.[Id]
                                   ,F.[Codigo]
                                   ,F.[Descricao]
                                   ,F.[Ativo]
                                   ,F.[DataCadastro]
                                   ,F.[DataUltimaAtualizacao]
                                   ,F.[InventarioId]
                                   ,F.[StatusRegistroId]
                                   ,F.[UsuarioCadastroId]
                                   ,F.[UsuarioAtualizacaoId]
                                   ,F.[SistemaCadastroId]
                                   ,F.[SistemaAtualizacaoId]	
		                           ,St.Descricao as StatusRegistros    
		                           ,S1.Nome as SistemaCadastro 
		                           ,S2.Nome as SistemaAtualizacao   
		                           ,U1.Email AS UsuarioCadastro
		                           ,U2.Email AS UsuarioAtualizacao                           
                               FROM [Inventarios].[Filiais] F
                          LEFT JOIN [Inventarios].[StatusRegistros] St on St.Id = F.StatusRegistroId
                          LEFT JOIN [Inventarios].[Sistemas] S1 on S1.Id = F.SistemaCadastroId
                          LEFT JOIN [Inventarios].[Sistemas] S2 on S2.Id = F.SistemaAtualizacaoId 
                          LEFT JOIN [Inventarios].[Usuarios] U1 on U1.Id = F.UsuarioCadastroId
                          LEFT JOIN [Inventarios].[Usuarios] U2 on U2.Id = F.UsuarioAtualizacaoId " + filtro + " " + ordem;

            return conn.Query<Filial>(sql, commandType: CommandType.Text).ToList();
        }

        public List<Filial> GetFiliaisData(int id, DateTime data)
        {
            string sql = @" SELECT * FROM Inventarios.Filiais where InventarioId = " + id + " and (DataUltimaAtualizacao >= @DataConsultar or DataUltimaAtualizacao is null) ";

            return conn.Query<Filial>(sql, new { DataConsultar = data }, commandTimeout: 240, commandType: CommandType.Text).ToList();
        }

        public bool GravarFiliais(Filial obj)
        {

            string sqlQuery = "";
            if (obj.Id == 0)
            {
                #region INSERT

                sqlQuery = @"INSERT INTO [Inventarios].[Filiais]
                                        ([Codigo]
                                        ,[Descricao]
                                        ,[Ativo]
                                        ,[DataCadastro]
                                        ,[DataUltimaAtualizacao]
                                        ,[InventarioId]
                                        ,[StatusRegistroId]
                                        ,[UsuarioCadastroId]
                                        ,[UsuarioAtualizacaoId]
                                        ,[SistemaCadastroId]
                                        ,[SistemaAtualizacaoId])
                                    VALUES
                                        (@Codigo
                                        ,@Descricao
                                        ,@Ativo
                                        ,@DataCadastro
                                        ,@DataUltimaAtualizacao
                                        ,@InventarioId
                                        ,@StatusRegistroId
                                        ,@UsuarioCadastroId
                                        ,@UsuarioAtualizacaoId
                                        ,@SistemaCadastroId
                                        ,@SistemaAtualizacaoId)";

                using (SqlCommand dataCommand = new SqlCommand(sqlQuery, conn))
                {
                    dataCommand.Parameters.AddWithValue("@Codigo", obj.Codigo);
                    dataCommand.Parameters.AddWithValue("@Descricao", obj.Descricao);
                    dataCommand.Parameters.AddWithValue("@Ativo", obj.Ativo);
                    dataCommand.Parameters.AddWithValue("@DataCadastro", obj.DataCadastro);
                    dataCommand.Parameters.AddWithValue("@DataUltimaAtualizacao", obj.DataUltimaAtualizacao);
                    dataCommand.Parameters.AddWithValue("@InventarioId", obj.InventarioId);
                    dataCommand.Parameters.AddWithValue("@StatusRegistroId", obj.StatusRegistroId);
                    dataCommand.Parameters.AddWithValue("@UsuarioCadastroId", obj.UsuarioCadastroId);
                    dataCommand.Parameters.AddWithValue("@UsuarioAtualizacaoId", obj.UsuarioAtualizacaoId);
                    dataCommand.Parameters.AddWithValue("@SistemaCadastroId", obj.SistemaCadastroId);
                    dataCommand.Parameters.AddWithValue("@SistemaAtualizacaoId", obj.SistemaAtualizacaoId);
                    return (dataCommand.ExecuteNonQuery() != 0);
                }

                #endregion
            }
            else
            {
                #region UPDATE

                sqlQuery = @"  UPDATE [Inventarios].[Filiais]
                               SET [Descricao] = @Descricao 
                                  ,[Ativo] = @Ativo
                                  ,[StatusRegistroId] = @StatusRegistroId
                                  ,[DataUltimaAtualizacao] = @DataUltimaAtualizacao 
                                  ,[UsuarioAtualizacaoId] = @UsuarioAtualizacaoId 
                                  ,[SistemaAtualizacaoId] = @SistemaAtualizacaoId 
                               WHERE Id = @Id";

                using (SqlCommand dataCommand = new SqlCommand(sqlQuery, conn))
                {
                    dataCommand.Parameters.AddWithValue("@Descricao", obj.Descricao);
                    dataCommand.Parameters.AddWithValue("@Ativo", obj.Ativo);
                    dataCommand.Parameters.AddWithValue("@DataUltimaAtualizacao", obj.DataUltimaAtualizacao);
                    dataCommand.Parameters.AddWithValue("@StatusRegistroId", obj.StatusRegistroId);
                    dataCommand.Parameters.AddWithValue("@UsuarioAtualizacaoId", obj.UsuarioAtualizacaoId);
                    dataCommand.Parameters.AddWithValue("@SistemaAtualizacaoId", obj.SistemaAtualizacaoId);
                    dataCommand.Parameters.AddWithValue("@Id", obj.Id);
                    return (dataCommand.ExecuteNonQuery() != 0);
                }

                #endregion
            }
        }

        public bool ExcluirCadastros(string filtro)
        {
            string sqlQuery = " DELETE FROM  [Inventarios].[Filiais] " + filtro;

            using (SqlCommand dataCommand = new SqlCommand(sqlQuery, conn))
            {
                return (dataCommand.ExecuteNonQuery() != 0);
            }
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
