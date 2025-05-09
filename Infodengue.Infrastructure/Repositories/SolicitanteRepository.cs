using Infodengue.Domain.Entities;
using Infodengue.Domain.Interfaces;
using Infodengue.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infodengue.Infrastructure.Repositories
{
    public class SolicitanteRepository : RepositoryBase<Solicitante>, ISolicitanteRepository
    {
        public SolicitanteRepository(InfodengueContext context) : base(context) { }

        public async Task<Solicitante?> GetByCPFAsync(string cpf)
        {
            return await _context.Solicitantes
                .Include(s => s.Relatorios)
                .FirstOrDefaultAsync(s => s.CPF == cpf);
        }
    }
}
