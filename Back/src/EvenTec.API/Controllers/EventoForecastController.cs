﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvenTec.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EvenTec.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
        public EventoController()
        {
            
        }

        public IEnumerable<Evento> _evento = new Evento[] {
            new Evento () {
            EventoId = 1,
            Local = "Jardim Alvorada",
            Lote = "1º Lote",
            QtdPessoas = 250,
            DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
            Tema = "Técnologia",
            ImagemURL = "Foto.png"
            },
            new Evento () {
            EventoId = 2,
            Local = "Jardim Alvorada",
            Lote = "2º Lote",
            QtdPessoas = 150,
            DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
            Tema = "Técnologia",
            ImagemURL = "Foto.png"
            }
            };
        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }
        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(evento => evento.EventoId == id);
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
