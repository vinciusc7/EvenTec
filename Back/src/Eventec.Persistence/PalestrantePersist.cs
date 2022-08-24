using System.Linq;
using System.Threading.Tasks;
using Eventec.Domain;
using Eventec.Persistence.Contratos;
using EvenTec.Persistence.Contextos;
using Microsoft.EntityFrameworkCore;

namespace Eventec.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly EventecContext _context;
        public PalestrantePersist(EventecContext context)
        {
            _context = context;
        }

        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedeSocial);

            if (includeEventos)
            {
                query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedeSocial);

            if (includeEventos)
            {
                query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id)
                                .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetAllPalestranteByIdAsync(int palestranteId, bool includeEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedeSocial);

            if (includeEventos)
            {
                query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id)
                                .Where(p => p.Id == palestranteId);
            return await query.FirstOrDefaultAsync();
        }
    }
}