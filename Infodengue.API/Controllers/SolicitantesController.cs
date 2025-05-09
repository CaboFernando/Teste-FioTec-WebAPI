using Infodengue.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Infodengue.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitantesController : ControllerBase
    {
        private readonly ISolicitanteRepository _repo;

        public SolicitantesController(ISolicitanteRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Lista todos os solicitantes que já requisitaram relatórios.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ListarSolicitantes()
        {
            var solicitantes = await _repo.GetAllAsync();
            return Ok(solicitantes.Select(s => new { s.Nome, s.CPF }));
        }
    }
}
