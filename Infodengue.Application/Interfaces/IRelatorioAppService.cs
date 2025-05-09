using Infodengue.Application.DTOs;

namespace Infodengue.Application.Interfaces
{
    public interface IRelatorioAppService
    {
        Task<RelatorioDto> ConsultarRelatorioAsync(SolicitacaoRelatorioDto solicitacaoDto);
        Task<IEnumerable<RelatorioDto>> ListarRelatoriosAsync();
    }
}
