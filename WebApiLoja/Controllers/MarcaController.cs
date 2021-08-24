using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiLoja.DAO;
using WebApiLoja.Model;

namespace WebApiLoja.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/marca")]
    public class MarcaController : ControllerBase
    {
        private const int qtdePorPagina = 12;
        private readonly MarcaDao marcaDao;
        public int PaginaAtual { get; set; }
        public int QtdePaginas { get; set; }
        public MarcaController()
        {
            marcaDao = new MarcaDao();
        }

        /// <summary>
        /// Este serviço permite obter uma lista de Marcas
        /// </summary>
        /// <returns>Retorna status ok e lista de Marcas</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter lista de Marcas", Type = typeof(MarcaModel))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        public async Task<List<MarcaModel>> listaMarca()
        {
            try
            {
                return await marcaDao.GetMarcas();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


 //       public async Task<List<MarcaModel>> listaMarcaPaginada(Paginacao paginacao)
 //       {
 //           try
 //           {
 ////               return await marcaDao.GetMarcas();
 //               return Task.FromResult(PagedList<MarcaModel>.GetPagedList(GetMarcas(),paginacao.PageNumber,paginacao.PageSize));
 //           }
 //           catch (Exception e)
 //           {
 //               throw new Exception(e.Message);
 //           }
 //       }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<MarcaModel> inserirMarca([FromBody] MarcaModel marcaModel)
        {
            try
            {
                await marcaDao.InserirMarca(marcaModel);
                return marcaModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public async Task<MarcaModel> alterarMarca(MarcaModel marcaModel)
        {
            try
            {
                marcaDao.AtualizarMarca(marcaModel);
                return marcaModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete]
        [Route("/{idMarca}")]
        public async Task excluirMarca(long idMarca)
        {
            try
            {
                marcaDao.ExcluirMarca(idMarca);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("/{idMarca}")]
        public async Task<MarcaModel> marcaPorId(long idMarca)
        {
            try
            {
                return await marcaDao.GetMarcaPorId(idMarca);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
