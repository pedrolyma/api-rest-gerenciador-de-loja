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
    [Route("api/v1/grades")]
    public class GradeController : ControllerBase
    {
        private readonly GradeDao gradeDao;
        public GradeController()
        {
            gradeDao = new GradeDao();
        }

        /// <summary>
        /// Este serviço permite obter uma lista de Secao
        /// </summary>
        /// <returns>Retorna status ok e lista de Secao</returns>
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao obter lista de Secao", Type = typeof(GradeModel))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        [EnableCors("SpecificOrigin")]
        [HttpGet]
        public async Task<List<GradeModel>> listaGrade()
        {
            try
            {
                return await gradeDao.GetGrades();
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
        [SwaggerResponse(statusCode: 201, description: "Sucesso ao obter lista de Secao", Type = typeof(GradeModel))]
        [SwaggerResponse(statusCode: 401, description: "Não autorizado")]
        //      [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<GradeModel> inserirGrade([FromBody] GradeModel gradeModel)
        {
            try
            {
                await gradeDao.InserirGrade(gradeModel);
                return gradeModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut]
        public async Task<GradeModel> alterarGrade(GradeModel gradeModel)
        {
            try
            {
                gradeDao.AtualizarGrade(gradeModel);
                return gradeModel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete]
        [Route("/{idGrade}")]
        public async Task excluirGrade(long idGrade)
        {
            try
            {
                gradeDao.ExcluirGrade(idGrade);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("/{idGrade}")]
        public async Task<GradeModel> gradePorId(long idGrade)
        {
            try
            {
                return await gradeDao.GetGradePorId(idGrade);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
