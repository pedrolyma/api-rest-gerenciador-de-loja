using Microsoft.AspNetCore.Cors;
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
    [Route("api/v1/secao")]
    public class SecaoController : ControllerBase
    {
        private readonly SecaoDao secaoDao;
        public SecaoController()
        {
            secaoDao = new SecaoDao();
        }

        /// <summary>
        /// Este serviço permite obter uma lista de Secao
        /// </summary>
        /// <returns>Retorna status ok e lista de Secao</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter lista de Secao", Type = typeof(SecaoModel))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [EnableCors("SpecificOrigin")]
        [HttpGet]
        public async Task<List<SecaoModel>> listaSecao()
        {
            try
            {
                return await secaoDao.GetSecoes();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Este serviço permite obter uma lista de Secao
        /// </summary>
        /// <returns>Retorna status ok e lista de Secao</returns>
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao obter lista de Secao", Type = typeof(SecaoModel))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
  //      [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<SecaoModel> inserirSecao([FromBody] SecaoModel secaoModel)
        {
            try
            {
                await secaoDao.InserirSecao(secaoModel);
                return secaoModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public async Task<SecaoModel> alterarSecao(SecaoModel secaoModel)
        {
            try
            {
                secaoDao.AtualizarSecao(secaoModel);
                return secaoModel;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        [HttpDelete]
        [Route("/{idSecao}")]
        public async Task excluirSecao(long idSecao)
        {
            try
            {
                secaoDao.ExcluirSecao(idSecao);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("/{idSecao}")]
        public async Task<SecaoModel> secaoPorId(long idSecao)
        {
            try
            {
                return await secaoDao.GetSecaoPorId(idSecao);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
