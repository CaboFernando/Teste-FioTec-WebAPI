using Infodengue.Domain.Entities;

namespace Infodengue.Domain.Interfaces
{
    public interface ISolicitanteRepository : IRepositoryBase<Solicitante>
    {
        Task<Solicitante?> GetByCPFAsync(string cpf);
    }
}
