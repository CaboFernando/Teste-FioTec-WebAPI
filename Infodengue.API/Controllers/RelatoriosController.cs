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
    }
}
