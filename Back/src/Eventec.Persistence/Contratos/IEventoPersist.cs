using System.Threading.Tasks;
using EvenTec.Domain;

namespace Eventec.Persistence.Contratos
{
    public interface IEventoPersist
    {
        //EVENTOS
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false);
    }
}