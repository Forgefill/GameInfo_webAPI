using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab2ICTP.Models;

namespace Lab2ICTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ESRBsController : ControllerBase
    {
        private readonly DBGameContext _context;

        public ESRBsController(DBGameContext context)
        {
            _context = context;
        }

        // GET: api/ESRBs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ESRB>>> GetESRBs()
        {
            return await _context.ESRBs.ToListAsync();
        }

        // GET: api/ESRBs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ESRB>> GetESRB(int id)
        {
            var eSRB = await _context.ESRBs.FindAsync(id);

            if (eSRB == null)
            {
                return NotFound();
            }

            return eSRB;
        }

        // PUT: api/ESRBs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutESRB(int id, ESRB eSRB)
        {
            if (id != eSRB.ESRBId)
            {
                return BadRequest();
            }

            _context.Entry(eSRB).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ESRBExists(id))
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

        // POST: api/ESRBs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ESRB>> PostESRB(ESRB eSRB)
        {
            _context.ESRBs.Add(eSRB);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetESRB", new { id = eSRB.ESRBId }, eSRB);
        }

        // DELETE: api/ESRBs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteESRB(int id)
        {
            var eSRB = await _context.ESRBs.FindAsync(id);
            if (eSRB == null)
            {
                return NotFound();
            }

            _context.ESRBs.Remove(eSRB);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ESRBExists(int id)
        {
            return _context.ESRBs.Any(e => e.ESRBId == id);
        }
    }
}
