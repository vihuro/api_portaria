using api_portaria.Dto.Entrada;
using api_portaria.Dto.Responsavel;
using api_portaria.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api_portaria.Controllers
{
    [ApiController]
    [Route("api/v1/entrada")]
    public class EntradaController : ControllerBase
    {
        private readonly IEntradaService _service;

        public EntradaController(IEntradaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<ReturnEntradaDto>> InsertEntrada(InsertEntradaDto dto) 
        {
            try
            {
                var result = await _service.InsertEntrada(dto);
                return Created("",result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ReturnEntradaDto>>> GetAll()
        {
            try
            {
                var result = await _service.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
