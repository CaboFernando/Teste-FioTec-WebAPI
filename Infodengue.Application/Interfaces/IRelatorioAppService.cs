using Infodengue.Application.DTOs;

namespace Infodengue.Application.Interfaces
{
    public interface IRelatorioAppService
    {
        Task<RelatorioDto> ConsultarRelatorioAsync(SolicitacaoRelatorioDto solicitacaoDto);
        Task<IEnumerable<RelatorioDto>> ListarRelatoriosAsync();
        Task<IEnumerable<RelatorioDto>> FiltrarPorIbgePeriodoArboviroseAsync(string codigoIbge, int semanaInicio, int semanaFim, string arbovirose);
        Task<IEnumerable<object>> TotalPorArboviroseAsync();
        Task<IEnumerable<object>> TotalPorCidadeAsync();
        Task<IEnumerable<RelatorioDto>> RelatoriosPorCidadesAsync();

    }
}
