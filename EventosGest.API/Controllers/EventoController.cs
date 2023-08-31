using EventosGest.API.Entites;
using EventosGest.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventosGest.API.Controllers
{
    [Route("api/gest-eventos")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly EventoDbContext _context;
        public EventoController(EventoDbContext context)
        {
            _context = context;
        }
        //api/gest-eventos GET
        [HttpGet]
        public IActionResult GetAll()
        {
            var eventos = _context.Eventos.
                Include(x=>x.Oradores).
                Where(e => !e.FoiExcluido).ToList();
            return Ok(eventos);
        }

        //api/gest-eventos/1234 GET
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var evento = _context.Eventos.SingleOrDefault(e => e.Id == id);
            if (evento == null)
                return NotFound();
            return Ok(evento);

        }

        //api/gest-eventos/ POST
        [HttpPost]
        public IActionResult Post(Evento evento)
        {
            _context.Eventos.Add(evento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = evento.Id }, evento);
        }

        //api/gest-eventos/1234/EVENTO PUT
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Evento input)
        {
            var evento = _context.Eventos.SingleOrDefault(e => e.Id == id);
            if (evento == null)
                return NotFound();
            evento.Update(input.Titulo, input.Descricao, input.Inicio, input.Termino);
            _context.Eventos.Update(evento);
            _context.SaveChanges();
            return NoContent();
        }

        //api/gest-eventos/1234 DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var evento = _context.Eventos.SingleOrDefault(e => e.Id == id);
            if (evento == null)
                return NotFound();
            evento.Delete();
            _context.SaveChanges();
            return NoContent();
        }
        //api/gest-eventos/
        [HttpPost("{id}/orador")]
        public IActionResult PostOrador(Guid id, EventoOrador orador)
        {
            orador.EventoId = id;
            var evento = _context.Eventos.Any(e => e.Id == id);
            if (!evento)
                return NotFound();
            _context.Oradores.Add(orador);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
