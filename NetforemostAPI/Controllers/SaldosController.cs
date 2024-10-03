using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetforemostAPI.Repository;

namespace NetforemostAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaldosController : ControllerBase
    {
        private readonly ISaldosRepository _saldosRepository;
        public SaldosController(ISaldosRepository saldosRepository)
        {
            _saldosRepository = saldosRepository;
        }

        [HttpGet("gestores")]
        public async Task<IActionResult> GetGestores()
        {
            var gestores = await _saldosRepository.GetGestores();
            return Ok(gestores);
        }

        [HttpGet]
        public async Task<IActionResult> getSaldosAsignados()
        {
            var saldosAsignados = await _saldosRepository.GetSaldos();
            return Ok(saldosAsignados);
        }
    }
}
