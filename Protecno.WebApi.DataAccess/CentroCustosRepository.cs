using Dapper;
using Prospere.Inventario.DAO;
using Protecno_Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace Projeto_DataAccess
{
    public class CentroCustosDAO
    {
        public List<CentroCustos> GetCentroCustos(string filtro, string ordem)
        {
            List<CentroCustos> list = new List<CentroCustos>();

            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Context"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    {
                        db.Open();
                    }

                    string sql = @"  SELECT  CC.[Id]
                                            ,CC.[Codigo]
                                            ,CC.[Descricao]
                                            ,CC.[Ativo]
                                            ,CC.[DataCadastro]
                                            ,CC.[DataUltimaAtualizacao]
                                            ,CC.[InventarioId]
                                            ,CC.[StatusRegistroId]
                                            ,CC.[UsuarioCadastroId]
                                            ,CC.[UsuarioAtualizacaoId]
                                            ,CC.[SistemaCadastroId]
                                            ,CC.[SistemaAtualizacaoId] 
                                            ,St.Descricao as StatusRegistros    
		                                    ,S1.Nome as SistemaCadastro 
		                                    ,S2.Nome as SistemaAtualizacao   
		                                    ,U1.Email AS UsuarioCadastro
		                                    ,U2.Email AS UsuarioAtualizacao 
                                        FROM [Inventarios].[CentroCustos] CC
                                    LEFT JOIN [Inventarios].[StatusRegistros] St on St.Id = CC.StatusRegistroId
                                    LEFT JOIN [Inventarios].[Sistemas] S1 on S1.Id = CC.SistemaCadastroId
                                    LEFT JOIN [Inventarios].[Sistemas] S2 on S2.Id = CC.SistemaAtualizacaoId 
                                    LEFT JOIN [Inventarios].[Usuarios] U1 on U1.Id = CC.UsuarioCadastroId
                                    LEFT JOIN [Inventarios].[Usuarios] U2 on U2.Id = CC.UsuarioAtualizacaoId " + filtro + " " + ordem;
                     
                    list = db.Query<CentroCustos>(sql, commandTimeout: 240, commandType: CommandType.Text).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        public List<CentroCustos> GetCentroCustosData(int id, DateTime data)
        {
            List<CentroCustos> list = new List<CentroCustos>();

            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Context"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    {
                        db.Open();
                    }

                    string sql = @" SELECT Id 
                                          ,Codigo
                                          ,Descricao
                                          ,Ativo
                                          ,DataCadastro
                                          ,DataUltimaAtualizacao
                                          ,InventarioId
                                          ,StatusRegistroId
                                          ,UsuarioCadastroId
                                          ,UsuarioAtualizacaoId
                                          ,SistemaCadastroId
                                          ,SistemaAtualizacaoId  
                                     FROM Inventarios.CentroCustos
                                    where InventarioId = " + id + " and (DataUltimaAtualizacao >= @DataConsultar or DataUltimaAtualizacao is null)";
                     
                    list = db.Query<CentroCustos>(sql, new { DataConsultar = data }, commandTimeout: 240, commandType: CommandType.Text).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
         
        public int GravarCentroCustos(CentroCustos obj)
        {
            int retorno;
            string sqlQuery = "";
            if (obj.Id == 0)
            {
                #region INSERT
                sqlQuery = @"INSERT INTO [Inventarios].[CentroCustos]
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

                try
                {
                    using (SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Context"].ConnectionString))
                    {
                        using (SqlCommand dataCommand = new SqlCommand(sqlQuery, db))
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

                            db.Open();
                            retorno = dataCommand.ExecuteNonQuery();
                            db.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                #endregion
            }
            else
            {
                #region UPDATE 
                sqlQuery = @"  UPDATE [Inventarios].[CentroCustos]
                               SET [Codigo] = @Codigo
                                  ,[Descricao] = @Descricao 
                                  ,[Ativo] = @Ativo  
                                  ,[StatusRegistroId] = @StatusRegistroId 
                                  ,[UsuarioAtualizacaoId] = @UsuarioAtualizacaoId 
                                  ,[SistemaAtualizacaoId] = @SistemaAtualizacaoId 
                                  ,[DataUltimaAtualizacao] = @DataUltimaAtualizacao
                               WHERE Id = @Id";
                try
                {
                    using (SqlConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["Context"].ConnectionString))
                    {
                        using (SqlCommand dataCommand = new SqlCommand(sqlQuery, db))
                        {
                            dataCommand.Parameters.AddWithValue("@Codigo", obj.Codigo);
                            dataCommand.Parameters.AddWithValue("@Descricao", obj.Descricao);
                            dataCommand.Parameters.AddWithValue("@Ativo", obj.Ativo);
                            dataCommand.Parameters.AddWithValue("@StatusRegistroId", obj.StatusRegistroId);
                            dataCommand.Parameters.AddWithValue("@UsuarioAtualizacaoId", obj.UsuarioAtualizacaoId);
                            dataCommand.Parameters.AddWithValue("@SistemaAtualizacaoId", obj.SistemaAtualizacaoId);
                            dataCommand.Parameters.AddWithValue("@DataUltimaAtualizacao", obj.DataUltimaAtualizacao);
                            dataCommand.Parameters.AddWithValue("@Id", obj.Id);

                            db.Open();
                            retorno = dataCommand.ExecuteNonQuery();
                            db.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                #endregion
            }
            return retorno;
        }

        public int ExcluirCadastros(string filtro)
        {
            int retorno = 0;

            string sqlQuery = " DELETE FROM [Inventarios].[CentroCustos] " + filtro;
            try
            {
                retorno = SqlHelper.ExecuteNonQuery(CommandType.Text, sqlQuery);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }
    }
}
