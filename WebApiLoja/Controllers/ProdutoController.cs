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
    [Route("api/v1/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoDao produtoDao;

        public ProdutoController()
        {
            produtoDao = new ProdutoDao();
        }

        [HttpGet]
        public async Task<List<ProdutoModel>> ListaProdutos()
        {
            try
            {
                return await produtoDao.listaProdutos();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ProdutoModel> InserirProduto([FromBody] ProdutoModel objProduto)
        {
            try
            {
                await produtoDao.InserirProduto(objProduto);
                return objProduto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public async Task<ProdutoModel> AltetarProduto(ProdutoModel objProduto)
        {
            try
            {
                produtoDao.AlterarProduto(objProduto);
                return objProduto;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete]
        [Route("/{idProduto}")]
        public async Task ExcluirProduto(long idProduto)
        {
            try
            {
                produtoDao.ExcluirProduto(idProduto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("/{idProduto}")]
        public async Task<ProdutoModel> ProdutoPorId(long idProduto)
        {
            try
            {
                return await produtoDao.GetProdutoPorId(idProduto);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
