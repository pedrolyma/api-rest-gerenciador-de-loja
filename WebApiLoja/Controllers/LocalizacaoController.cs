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
    [Route("api/v1/localizacao")]
    public class LocalizacaoController : ControllerBase
    {
        private readonly LocalizacaoDao localizacaoDao;
        public LocalizacaoController()
        {
            localizacaoDao = new LocalizacaoDao();
        }

        /// <summary>
        /// Este serviço permite obter uma lista de Localizacao
        /// </summary>
        /// <returns>Retorna status ok e lista de Localizacao</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter lista de Secao", Type = typeof(LocalizacaoModel))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [HttpGet]
        public async Task<List<LocalizacaoModel>> listaLocalizacao()
        {
            try
            {
                return await localizacaoDao.GetLocalizacoes();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<LocalizacaoModel> inserirLocalizacao([FromBody] LocalizacaoModel localizacaoModel)
        {
            try
            {
                await localizacaoDao.InserirLocalizacao(localizacaoModel);
                return localizacaoModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public async Task<LocalizacaoModel> alterarLocalizacao(LocalizacaoModel localizacaoModel)
        {
            try
            {
                localizacaoDao.AtualizarLocalizacao(localizacaoModel);
                return localizacaoModel;
            }
            catch (Exception e) { throw new Exception(e.Message); }
        }

        [HttpDelete]
        [Route("/{idLocalizacao}")]
        public async Task excluirLocalizacao(long idLocalizacao)
        {
            try
            {
                localizacaoDao.ExcluirLocalizacao(idLocalizacao);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("/{idLocalizacao}")]
        public async Task<LocalizacaoModel> localizacaoPorId(long idLocalizacao)
        {
            try
            {
                return await localizacaoDao.GetLocalizacaoPorId(idLocalizacao);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
