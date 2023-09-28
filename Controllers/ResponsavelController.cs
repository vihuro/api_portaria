using api_portaria.Dto.Responsavel;
using api_portaria.Interface;
using Microsoft.AspNetCore.Mvc;

namespace api_portaria.Controllers
{
    [ApiController]
    [Route("api/v1/responsavel")]
    public class ResponsavelController : ControllerBase
    {
        private readonly IResponsavelService _service;

        public ResponsavelController(IResponsavelService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> InsertResponsavel(InsertResponsavelDto dto)
        {
            try
            {
                var result = await _service.InsertResponsavel(dto);
                return Created("", result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ReturnResponsavelDto>>> GetAll()
        {
            try
            {
                var list = await _service.GetAll();
                return Ok(list);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
