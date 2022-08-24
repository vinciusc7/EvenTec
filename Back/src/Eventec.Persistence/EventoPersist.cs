using System.Linq;
using System.Threading.Tasks;
using Eventec.Persistence.Contratos;
using EvenTec.Domain;
using EvenTec.Persistence.Contextos;
using Microsoft.EntityFrameworkCore;

namespace Eventec.Persistence
{
    public class EventoPersist : IEventoPersist
    {
        private readonly EventecContext _context;
        public EventoPersist(EventecContext context)
        {
            _context = context;
        }
      
        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.palestrante);
            }

            query = query.OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.palestrante);
            }

            query = query.OrderBy(e => e.Id)
                        .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
            return await query.ToArrayAsync();
        }

        public  async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.palestrante);
            }

            query = query.OrderBy(e => e.Id)
                        .Where(e => e.Id == eventoId );
            ;
            return await query.FirstOrDefaultAsync();
        }
    }
}