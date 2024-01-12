using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmpleadoCrud.Server.Models;
using EmpleadoCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace EmpleadoCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly DbcrudEmpleadosContext _dbContext;
        public DepartamentoController(DbcrudEmpleadosContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<ActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<DepartamentoDTO>>();
            var listaDepartamentoDTO = new List<DepartamentoDTO>();

            try
            {
                foreach (var item in await _dbContext.Departamentos.ToListAsync())
                {
                    listaDepartamentoDTO.Add(new DepartamentoDTO
                    {
                        IdDepartamento = item.IdDepartamento,
                        Nombre = item.Nombre
                    });
                }

                responseApi.EsCorrecto = true;
                responseApi.Valor = listaDepartamentoDTO;
            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }
    }
}