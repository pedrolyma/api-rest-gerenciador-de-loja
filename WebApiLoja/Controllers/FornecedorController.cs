using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    [Route("api/v1/fornecedores")]
    public class FornecedorController : ControllerBase
    {
        private readonly FornecedorDao fornecedorDao;

        public FornecedorController()
        {
            fornecedorDao = new FornecedorDao();
        }

        [HttpGet]
        public async Task<List<FornecedorModel>> ListaFornecedor()
        {
            try
            {
                return await fornecedorDao.listaFornecedor();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<FornecedorModel> InserirFornecedor([FromBody] FornecedorModel objFornecedor)
        {
            try
            {
                await fornecedorDao.InserirFornecedor(objFornecedor);
                return objFornecedor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public async Task<FornecedorModel> AltetarFornecedor(FornecedorModel objFornecedor)
        {
            try
            {
                fornecedorDao.AlterarFornecedor(objFornecedor);
                return objFornecedor;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete]
        [Route("/{idFornecedor}")]
        public async Task ExcluirFornecedor(long idFornecedor)
        {
            try
            {
                fornecedorDao.ExcluirFornecedor(idFornecedor);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("/{idFornecedor}")]
        public async Task<FornecedorModel> FornecedorPorId(long idFornecedor)
        {
            try
            {
                return await fornecedorDao.GetFornecedorPorId(idFornecedor);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
