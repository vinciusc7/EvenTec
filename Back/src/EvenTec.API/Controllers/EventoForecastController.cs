﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvenTec.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EvenTec.Domain;
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
