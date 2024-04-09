using CoffeeTrackerApi.Data;
using CoffeeTrackerApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeTrackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly CoffeeTrackerApiContext _context;

        public RecordsController(CoffeeTrackerApiContext context)
        {
            _context = context;
        }

        // GET: api/Records
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Records>>> GetRecords()
        {
            return await _context.Records.ToListAsync();
        }

        // GET: api/Records/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Records>> GetRecords(int id)
        {
            var records = await _context.Records.FindAsync(id);

            if (records == null)
            {
                return NotFound();
            }

            return records;
        }

        // PUT: api/Records/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecords(int id, Records records)
        {
            if (id != records.Id)
            {
                return BadRequest();
            }

            _context.Entry(records).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordsExists(id))
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

        // POST: api/Records
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Records>> PostRecords(Records records)
        {
            _context.Records.Add(records);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecords", new { id = records.Id }, records);
        }

        // DELETE: api/Records/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecords(int id)
        {
            var records = await _context.Records.FindAsync(id);
            if (records == null)
            {
                return NotFound();
            }

            _context.Records.Remove(records);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecordsExists(int id)
        {
            return _context.Records.Any(e => e.Id == id);
        }
    }
}
