using Infodengue.Domain.Entities;

namespace Infodengue.Domain.Interfaces
{
    public interface IRelatorioRepository : IRepositoryBase<Relatorio>
    {
        Task<IEnumerable<Relatorio>> GetByMunicipioAsync(string municipio);
        Task<IEnumerable<Relatorio>> GetByIbgeCodeAsync(string ibgeCode);
        Task<IEnumerable<Relatorio>> GetByArboviroseAsync(string arbovirose);
    }
}
