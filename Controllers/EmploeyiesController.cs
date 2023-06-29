using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmploeyiesController : ControllerBase
    {
        private readonly DbProjectOfficeContext _context;

        public EmploeyiesController(DbProjectOfficeContext context)
        {
            _context = context;
        }

        // GET: api/Emploeyies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emploeyy>>> GetEmploeyys()
        {
          if (_context.Emploeyys == null)
          {
              return NotFound();
          }
            return await _context.Emploeyys.ToListAsync();
        }

        // GET: api/Emploeyies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emploeyy>> GetEmploeyy(int id)
        {
          if (_context.Emploeyys == null)
          {
              return NotFound();
          }
            var emploeyy = await _context.Emploeyys.FindAsync(id);

            if (emploeyy == null)
            {
                return NotFound();
            }

            return emploeyy;
        }

        // PUT: api/Emploeyies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploeyy(int id, Emploeyy emploeyy)
        {
            if (id != emploeyy.Id)
            {
                return BadRequest();
            }

            _context.Entry(emploeyy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmploeyyExists(id))
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

        // POST: api/Emploeyies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Emploeyy>> PostEmploeyy(Emploeyy emploeyy)
        {
          if (_context.Emploeyys == null)
          {
              return Problem("Entity set 'DbProjectOfficeContext.Emploeyys'  is null.");
          }
            _context.Emploeyys.Add(emploeyy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmploeyyExists(emploeyy.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmploeyy", new { id = emploeyy.Id }, emploeyy);
        }

        // DELETE: api/Emploeyies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmploeyy(int id)
        {
            if (_context.Emploeyys == null)
            {
                return NotFound();
            }
            var emploeyy = await _context.Emploeyys.FindAsync(id);
            if (emploeyy == null)
            {
                return NotFound();
            }

            _context.Emploeyys.Remove(emploeyy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmploeyyExists(int id)
        {
            return (_context.Emploeyys?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
