using Infodengue.Application.DTOs;
using Infodengue.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Infodengue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelatoriosController : ControllerBase
    {
        private readonly IRelatorioAppService _relatorioAppService;

        public RelatoriosController(IRelatorioAppService relatorioAppService)
        {
            _relatorioAppService = relatorioAppService;
        }

        /// <summary>
        /// Gera um novo relatório de arboviroses para um solicitante.
        /// </summary>
        [HttpPost("consultar")]
        public async Task<ActionResult<RelatorioDto>> ConsultarRelatorio([FromBody] SolicitacaoRelatorioDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var relatorio = await _relatorioAppService.ConsultarRelatorioAsync(dto);
            return Ok(relatorio);
        }

        /// <summary>
        /// Lista todos os relatórios salvos no banco de dados.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RelatorioDto>>> ListarRelatorios()
        {
            var relatorios = await _relatorioAppService.ListarRelatoriosAsync();
            return Ok(relatorios);
        }

        [HttpGet("filtro")]
        public async Task<IActionResult> FiltrarPorIbgePeriodoArbovirose([FromQuery] string codigoIbge, [FromQuery] int semanaInicio, [FromQuery] int semanaFim, [FromQuery] string arbovirose)
        {
            var result = await _relatorioAppService.FiltrarPorIbgePeriodoArboviroseAsync(codigoIbge, semanaInicio, semanaFim, arbovirose);
            return Ok(result);
        }

        [HttpGet("total-arboviroses")]
        public async Task<IActionResult> TotalPorArbovirose()
        {
            var result = await _relatorioAppService.TotalPorArboviroseAsync();
            return Ok(result);
        }

        [HttpGet("total-cidades")]
        public async Task<IActionResult> TotalPorCidade()
        {
            var result = await _relatorioAppService.TotalPorCidadeAsync();
            return Ok(result);
        }

        [HttpGet("relatorios-cidades")]
        public async Task<IActionResult> RelatoriosPorCidades()
        {
            var result = await _relatorioAppService.RelatoriosPorCidadesAsync();
            return Ok(result);
        }


    }
}
