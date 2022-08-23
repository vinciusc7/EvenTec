using System.Threading.Tasks;
using Eventec.Domain;
using EvenTec.Domain;

namespace Eventec.Persistence
{
    public interface IEventecPersistence
    {
        //GERAL
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         void DeleteRange<T>(T[] entity) where T: class;
         Task<bool> SaveChangesAsync(); 


        //EVENTOS
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventosTemaAsync(bool includePalestrantes);
        Task<Evento> GetAllEventoByIdAsync(int EventoId, bool includePalestrantes);

        //Palestrantes
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesTemaAsync(bool includeEventos);
        Task<Palestrante> GetAllPalestranteByIdAsync(int PalestranteId, bool includeEventos);
    }
}