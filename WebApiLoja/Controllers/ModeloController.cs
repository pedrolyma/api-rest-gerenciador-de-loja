using Microsoft.AspNetCore.Cors;
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
    [Route("api/v1/modelos")]
    public class ModeloController : ControllerBase
    {
        private readonly ModeloDao modeloDao;
        public ModeloController()
        {
            modeloDao = new ModeloDao();
        }

        /// <summary>
        /// Este serviço permite obter uma lista de Secao
        /// </summary>
        /// <returns>Retorna status ok e lista de Secao</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter lista de Secao", Type = typeof(ModeloModel))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [EnableCors("SpecificOrigin")]
        [HttpGet]
        public async Task<List<ModeloModel>> listaModelo()
        {
            try
            {
                return await modeloDao.GetModelos();
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
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao obter lista de Secao", Type = typeof(ModeloModel))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        //      [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ModeloModel> inserirModelo([FromBody] ModeloModel modeloModel)
        {
            try
            {
                await modeloDao.InserirModelo(modeloModel);
                return modeloModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public async Task<ModeloModel> alterarModelo(ModeloModel modeloModel)
        {
            try
            {
                modeloDao.AtualizarModelo(modeloModel);
                return modeloModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete]
        [Route("/{idModelo}")]
        public async Task excluirModelo(long idModelo)
        {
            try
            {
                modeloDao.ExcluirModelo(idModelo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("/{idModelo}")]
        public async Task<ModeloModel> modeloPorId(long idModelo)
        {
            try
            {
                return await modeloDao.GetModeloPorId(idModelo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
