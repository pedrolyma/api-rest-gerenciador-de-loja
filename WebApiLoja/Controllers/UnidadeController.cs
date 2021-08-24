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
    [Route("api/v1/unidades")]
    public class UnidadeController : ControllerBase
    {
        private readonly UnidadeDao unidadeDao;
        public UnidadeController()
        {
            unidadeDao = new UnidadeDao();
        }

        /// <summary>
        /// Este serviço permite obter uma lista de Secao
        /// </summary>
        /// <returns>Retorna status ok e lista de Secao</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter lista de Secao", Type = typeof(UnidadeModel))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        public async Task<List<UnidadeModel>> listaUnidade()
        {
            try
            {
                return unidadeDao.GetUnidades();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<UnidadeModel> inserirUnidade([FromBody] UnidadeModel unidadeModel)
        {
            try
            {
                unidadeDao.InserirUnidade(unidadeModel);
                return unidadeModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public async Task<UnidadeModel> alterarUnidade(UnidadeModel unidadeModel)
        {
            try
            {
                unidadeDao.AtualizarUnidade(unidadeModel);
                return unidadeModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete]
        [Route("/{idUnidade}")]
        public void excluirUnidade(long idUnidade)
        {
            try
            {
                unidadeDao.ExcluirUnidade(idUnidade);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("/{idUnidade}")]
        public UnidadeModel unidadePorId(long idUnidade)
        {
            try
            {
                return unidadeDao.GetUnidadePorId(idUnidade);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
