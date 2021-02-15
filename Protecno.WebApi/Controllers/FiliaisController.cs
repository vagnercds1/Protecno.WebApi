using Newtonsoft.Json;
using Projeto_DataAccess;
using Protecno.Core;
using Protecno.WebApi.Model;
using Protecno.WebApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Protecno.WebApi.Controllers
{
    public class FiliaisController : ApiController
    {
        FilialRepository repository;

        [AcceptVerbs("GET")]
        [Route("Filiais/GetFiliaisPorId/{id}")]
        public IHttpActionResult GetFiliaisPorId(int id)
        {
            try
            {
                repository = new FilialRepository();

                IQueryable<Filial> filiais = repository.GetFiliais(" where id = " + id, "").AsQueryable();

                return Ok(filiais);
            }
            catch (System.Exception ex)
            {
                Log.LogErro(ex, "", "Erro em GetFiliaisPorId (WebAPI)", "");
                return InternalServerError(ex);
            }
        }

        [AcceptVerbs("GET")]
        [Route("Filiais/GetFiliaisPorInventario/{id}")]
        public IHttpActionResult GetFiliaisPorInventario(int id)
        {
            try
            {
                repository = new FilialRepository();

                IQueryable<Filial> filiais = repository.GetFiliais(" where InventarioId = " + id, "").AsQueryable();

                return Ok(filiais);
            }
            catch (System.Exception ex)
            {
                Log.LogErro(ex, "", "Erro em GetFiliaisPorInventario (WebAPI)", "");
                return InternalServerError(ex);
            }
        }

        [AcceptVerbs("GET")]
        [Route("Filiais/GetFiliaisPorInventarioData/{id}/{data}")]
        public IHttpActionResult GetFiliaisPorInventario(int id, long data)
        {
            try
            {
                repository = new FilialRepository();

                DateTime dtresult = new DateTime(data);

                if (dtresult < new DateTime(2018, 1, 1))
                    dtresult = new DateTime(2018, 1, 1);

                IQueryable<Filial> filiais = repository.GetFiliaisData(id, dtresult).AsQueryable();

                return Ok(filiais);
            }
            catch (System.Exception ex)
            {
                Log.LogErro(ex, "", "Erro em GetFiliaisPorInventario (WebAPI)", "");
                return InternalServerError(ex);
            }
        }

        [AcceptVerbs("POST")]
        [Route("Filiais/PostListFiliais/{id}")]
        public IHttpActionResult PostListFiliais(int id, Filial[] listFiliais) //HttpResponseMessage
        {
            int linhasAfetadas = 0;
            string retorno = "";
            DateTime DATA;
            string serialized = "";
            try
            {
                using (var repository = new FilialRepository())
                {
                    foreach (var item in listFiliais)
                    {
                        Filial obj;

                        serialized = JsonConvert.SerializeObject(item);

                        // Em caso de erro ao gravar no banco, essa linha define qual é o registro exato que deu erro 
                        retorno = "Filial não gravada" +
                           "\r\n Codigo: " + item.Codigo +
                           "\r\n Descrição: " + item.Descricao.ToString() +
                           "\r\n Inventario Id:" + id.ToString() + " - " + new InventarioRepository().GetInventario(" where I.Id = " + id.ToString(), "")[0].NomeInventario +
                           "\r\n Usuário: " + new UsuarioRepository().GetUsuarios(" where U.Id = " + item.UsuarioAtualizacaoId, string.Empty)[0].Email;

                        DATA = (DateTime)item.DataUltimaAtualizacao;

                        List<Filial> list = repository.GetFiliais(" Where Codigo = '" + item.Codigo + "' and InventarioId =" + id, "");
                        obj = new Filial();
                        if (list.Count == 0)
                        {
                            obj.Id = 0;
                            obj.DataCadastro = item.DataCadastro;
                            obj.UsuarioCadastroId = item.UsuarioCadastroId;
                            obj.SistemaCadastroId = item.SistemaCadastroId;
                        }
                        else
                        {
                            obj.Id = list[0].Id;
                            obj.DataCadastro = list[0].DataCadastro;
                            obj.UsuarioCadastroId = list[0].UsuarioCadastroId;
                            obj.SistemaCadastroId = list[0].SistemaCadastroId;
                        }

                        obj.InventarioId = id;
                        obj.Codigo = item.Codigo;
                        obj.Descricao = item.Descricao;
                        obj.Ativo = item.Ativo;
                        obj.StatusRegistroId = item.StatusRegistroId;
                        obj.DataUltimaAtualizacao = item.DataUltimaAtualizacao;
                        obj.UsuarioAtualizacaoId = item.UsuarioAtualizacaoId;
                        obj.SistemaAtualizacaoId = item.SistemaAtualizacaoId;

                        repository.GravarFiliais(obj);

                        retorno = "Filiais Gravados " + linhasAfetadas + " itens em " + DATA.ToString("dd/MM/yyyy hh:mm:ss");
                    }
                } 
            }
            catch (Exception ex)
            {
                Log.LogErro(ex, "", "Erro em PostListFiliais (WebAPI)", serialized);
                return InternalServerError(ex);
            }

            return Ok();
        }
    }
}