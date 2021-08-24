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
    [Route("api/v1/cores")]
    public class CorController : ControllerBase
    {
        private readonly CorDao corDao;
        public CorController()
        {
            corDao = new CorDao();
        }

        /// <summary>
        /// Este serviço permite obter uma lista de Cores
        /// </summary>
        /// <returns>Retorna status ok e lista de Cores</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter lista de Cores", Type = typeof(CorModel))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        public async Task<List<CorModel>> listaCor()
        {
            try
            {
                return await corDao.GetCores();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

 //       [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<CorModel> inserirCor([FromBody] CorModel corModel)
        {
            try
            {
                corDao.InserirCor(corModel);
                return corModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public async Task<CorModel> alterarCor(CorModel corModel)
        {
            try
            {
                corDao.AtualizarCor(corModel);
                return corModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete]
        [Route("/{idCor}")]
        public void excluirCor(long idCor)
        {
            try
            {
                corDao.ExcluirCor(idCor);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("/{idCor}")]
        public async Task<CorModel> corPorId(long idCor)
        {
            try
            {
                return await corDao.GetCorPorId(idCor);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
