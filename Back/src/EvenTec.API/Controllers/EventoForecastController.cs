using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EvenTec.Domain;
using EvenTec.Persistence.Contextos;

namespace EvenTec.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly EventecContext _context;
        public EventoController(EventecContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }
        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.Eventos.FirstOrDefault(evento => evento.Id == id);
        }
        [HttpPost]
        public string Post()
        {
            return "Valor de Post";
        }
        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Valor de Put com id = {id}";
        }
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Valor de Delete com id = {id}";
        }
    }

}
