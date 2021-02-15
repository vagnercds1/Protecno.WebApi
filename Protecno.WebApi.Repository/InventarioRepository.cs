using Dapper;
using Protecno.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Projeto_DataAccess
{
    public class InventarioRepository : IDisposable
    {
        SqlConnection conn;
        public InventarioRepository()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Context"].ConnectionString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            } 
        }

        public List<Inventario> GetInventario(string filtro, string ordem)
        {
            string sql = @" SELECT  I.*, 
                                    S.Id SegmentoDeEmpresasId,
                                    S.Descricao Segmento,
		                            S.Definicao,
                                    S.CodigoHash CodigoHashPreCadastro,
		                            U.Email as UsuarioCadastro,
			                        B.CodigoHash CodigoHashInventario, 
			                        B.UsuarioId as UsuarioBaseMobileId, 
			                        B.CodigoHash,
			                        B.Status,
			                        B.DataHoraInicio, 
			                        B.DataHoraFim
                            FROM Inventario.Inventario I
                        left JOIN [PreCadastro].[SeguimentoDeEmpresas] S on S.Id = i.SeguimentoDeEmpresasId 
                        left JOIN [Inventario].[Usuarios] U on U.Id = I.Usuarios_Id
                        left join [Inventario].[BaseMobile] B on B.InventarioId = I.Id " + filtro + " " + ordem;

            return conn.Query<Inventario>(sql, CommandType.Text).ToList();
        }

        public List<Inventario> GetInventario(string filtro, string ordem, SqlConnection conn, SqlTransaction tran)
        {
            string sql = @" SELECT  I.*, 
		                            S.Descricao as Seguimento,
		                            U.Email as UsuarioCadastro
                             FROM Inventario.Inventario I
                        left JOIN [PreCadastro].[SeguimentoDeEmpresas] S on S.Id = i.SeguimentoDeEmpresasId 
                        left JOIN [Inventario].[Usuarios] U on U.Id = I.Usuarios_Id" + filtro + " " + ordem;

            return conn.Query<Inventario>(sql, CommandType.Text, tran).ToList();
        }

        public bool GravarInventario(Inventario obj, SqlConnection conn, SqlTransaction tran)
        {
            string sqlQuery = "";
            if (obj.Id == 0)
            {
                #region INSERT
                sqlQuery = @"  INSERT INTO [Inventario].[Inventario]
                                           ([NomeInventario]
                                           ,[Ativo]
                                           ,[DataCadastro]
                                           ,[Usuarios_Id]
                                           ,[Usuarios_Id1]
                                           ,[EmpresasId]
                                           ,[SeguimentoDeEmpresasId] )
                                     VALUES
                                           (@NomeInventario,
			                                @Ativo,
			                                @DataCadastro,
			                                @Usuarios_Id,
                                            @Usuarios_Id,	
			                                @EmpresasId,
			                                @SeguimentoDeEmpresasId ) ";
                #endregion
            }
            else
            {
                #region UPDATE 
                sqlQuery = @"  UPDATE [Inventario].[Inventario]
                                SET NomeInventario= @NomeInventario,	
                                    Ativo= @Ativo,	 	  	
                                    SeguimentoDeEmpresasId= @SeguimentoDeEmpresasId, 
                                    ChaveSincronismo= @ChaveSincronismo
                              WHERE Id = @Id";
                #endregion
            }

            using (SqlCommand dataCommand = new SqlCommand(sqlQuery, conn))
            {
                dataCommand.Transaction = tran;

                dataCommand.Parameters.AddWithValue("@NomeInventario", obj.NomeInventario);
                dataCommand.Parameters.AddWithValue("@Ativo", obj.Ativo);
                dataCommand.Parameters.AddWithValue("@DataCadastro", obj.DataCadastro);
                dataCommand.Parameters.AddWithValue("@Usuarios_Id", obj.Usuarios_Id);
                dataCommand.Parameters.AddWithValue("@EmpresasId", obj.EmpresasId);
                dataCommand.Parameters.AddWithValue("@SeguimentoDeEmpresasId", obj.SegmentoDeEmpresasId);

                if (obj.Id > 0)
                {
                    dataCommand.Parameters.AddWithValue("@Id", obj.Id);
                    dataCommand.Parameters.AddWithValue("@ChaveSincronismo", obj.ChaveSincronismo);
                }
                return (dataCommand.ExecuteNonQuery() != 0);
            }
        }

        public bool GravarInventario(Inventario obj)
        {
            string sqlQuery = "";
            if (obj.Id == 0)
            {
                #region INSERT
                sqlQuery = @"  INSERT INTO [Inventario].[Inventario]
                                           ([NomeInventario]
                                           ,[Ativo]
                                           ,[DataCadastro]
                                           ,[Usuarios_Id]
                                           ,[Usuarios_Id1]
                                           ,[EmpresasId]
                                           ,[SeguimentoDeEmpresasId] )
                                     VALUES
                                           (@NomeInventario,
			                                @Ativo,
			                                @DataCadastro,
			                                @Usuarios_Id,
                                            @Usuarios_Id,	
			                                @EmpresasId,
			                                @SeguimentoDeEmpresasId ) ";
                #endregion
            }
            else
            {
                #region UPDATE 
                sqlQuery = @"  UPDATE [Inventario].[Inventario]
                                SET NomeInventario= @NomeInventario,	
                                    Ativo= @Ativo,	 	  	
                                    SeguimentoDeEmpresasId= @SeguimentoDeEmpresasId, 
                                    ChaveSincronismo= @ChaveSincronismo
                              WHERE Id = @Id";
                #endregion
            }

            using (SqlCommand dataCommand = new SqlCommand(sqlQuery, conn))
            {
                dataCommand.Parameters.AddWithValue("@NomeInventario", obj.NomeInventario);
                dataCommand.Parameters.AddWithValue("@Ativo", obj.Ativo);
                dataCommand.Parameters.AddWithValue("@DataCadastro", obj.DataCadastro);
                dataCommand.Parameters.AddWithValue("@Usuarios_Id", obj.Usuarios_Id);
                dataCommand.Parameters.AddWithValue("@EmpresasId", obj.EmpresasId);
                dataCommand.Parameters.AddWithValue("@SeguimentoDeEmpresasId", obj.SegmentoDeEmpresasId);

                if (obj.Id > 0)
                {
                    dataCommand.Parameters.AddWithValue("@Id", obj.Id);
                    dataCommand.Parameters.AddWithValue("@ChaveSincronismo", obj.ChaveSincronismo);
                }

                return (dataCommand.ExecuteNonQuery() != 0);
            }
        }

        public bool ExcluirCadastros(string filtro)
        {
            string sqlQuery = " DELETE FROM  [Inventario].[Inventario] " + filtro;
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
