using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTful_Web_Services.Models;

namespace RESTful_Web_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunController : ControllerBase
    {
        private readonly ProductDBContext _context;

        public UrunController(ProductDBContext context)
        {
            _context = context;
        }

        // GET: api/Urun
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Urun>>> GetUruns()
        {
            return await _context.Uruns.ToListAsync();
        }

        // GET: api/Urun/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Urun>> GetUrun(int id)
        {
            var urun = await _context.Uruns.FindAsync(id);

            if (urun == null)
            {
                return NotFound();
            }

            return urun;
        }

        // PUT: api/Urun/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUrun(int id, Urun urun)
        {
            if (id != urun.UrunId)
            {
                return BadRequest();
            }

            _context.Entry(urun).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UrunExists(id))
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

        // POST: api/Urun
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Urun>> PostUrun(Urun urun)
        {
            _context.Uruns.Add(urun);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUrun", new { id = urun.UrunId }, urun);
        }

        // DELETE: api/Urun/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrun(int id)
        {
            var urun = await _context.Uruns.FindAsync(id);
            if (urun == null)
            {
                return NotFound();
            }

            _context.Uruns.Remove(urun);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UrunExists(int id)
        {
            return _context.Uruns.Any(e => e.UrunId == id);
        }
    }
}
