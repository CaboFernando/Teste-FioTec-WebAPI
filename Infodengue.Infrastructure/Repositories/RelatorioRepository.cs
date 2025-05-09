using Infodengue.Domain.Entities;
using Infodengue.Domain.Interfaces;
using Infodengue.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infodengue.Infrastructure.Repositories
{
    public class RelatorioRepository : RepositoryBase<Relatorio>, IRelatorioRepository
    {
        public RelatorioRepository(InfodengueContext context) : base(context) { }

        public async Task<IEnumerable<Relatorio>> GetByMunicipioAsync(string municipio)
        {
            return await _context.Relatorios.Where(r => r.Municipio == municipio).ToListAsync();
        }

        public async Task<IEnumerable<Relatorio>> GetByIbgeCodeAsync(string ibgeCode)
        {
            return await _context.Relatorios.Where(r => r.CodigoIbge == ibgeCode).ToListAsync();
        }

        public async Task<IEnumerable<Relatorio>> GetByArboviroseAsync(string arbovirose)
        {
            return await _context.Relatorios.Where(r => r.Arbovirose == arbovirose).ToListAsync();
        }
    }
}
