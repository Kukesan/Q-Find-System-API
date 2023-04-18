using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Qfind.Models;

namespace Qfind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Tickets1Controller : ControllerBase
    {
        private readonly QFindContext _context;

        public Tickets1Controller(QFindContext context)
        {
            _context = context;
        }

        // GET: api/Tickets1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tickets>>> GetTicketsEntity()
        {
          if (_context.TicketsEntity == null)
          {
              return NotFound();
          }
            return await _context.TicketsEntity.ToListAsync();
        }

        // GET: api/Tickets1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tickets>> GetTickets(int id)
        {
          if (_context.TicketsEntity == null)
          {
              return NotFound();
          }
            var tickets = await _context.TicketsEntity.FindAsync(id);

            if (tickets == null)
            {
                return NotFound();
            }

            return tickets;
        }

        // PUT: api/Tickets1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTickets(int id, Tickets tickets)
        {
            if (id != tickets.Id)
            {
                return BadRequest();
            }

            _context.Entry(tickets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tickets1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tickets>> PostTickets(Tickets tickets)
        {
          if (_context.TicketsEntity == null)
          {
              return Problem("Entity set 'QFindContext.TicketsEntity'  is null.");
          }
            _context.TicketsEntity.Add(tickets);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTickets", new { id = tickets.Id }, tickets);
        }

        // DELETE: api/Tickets1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTickets(int id)
        {
            if (_context.TicketsEntity == null)
            {
                return NotFound();
            }
            var tickets = await _context.TicketsEntity.FindAsync(id);
            if (tickets == null)
            {
                return NotFound();
            }

            _context.TicketsEntity.Remove(tickets);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketsExists(int id)
        {
            return (_context.TicketsEntity?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
