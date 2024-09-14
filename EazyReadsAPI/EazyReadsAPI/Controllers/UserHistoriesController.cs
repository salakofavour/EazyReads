using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EazyReadsAPI.Models;

namespace EazyReadsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserHistoriesController : ControllerBase
    {
        private readonly EazyReadsContext _context = new EazyReadsContext();

        /*public UserHistoriesController(EazyReadsContext context)
        {
            _context = context;
        }*/

        // GET: api/UserHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserHistory>>> GetUserHistories()
        {
            return await _context.UserHistories.ToListAsync();
        }

        // GET: api/UserHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserHistory>> GetUserHistory(int id)
        {
            var userHistory = await _context.UserHistories.FindAsync(id);

            if (userHistory == null)
            {
                return NotFound();
            }

            return userHistory;
        }

        // PUT: api/UserHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserHistory(int id, UserHistory userHistory)
        {
            if (id != userHistory.UserHid)
            {
                return BadRequest();
            }

            _context.Entry(userHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserHistoryExists(id))
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

        // POST: api/UserHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserHistory>> PostUserHistory(UserHistory userHistory)
        {
            _context.UserHistories.Add(userHistory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserHistoryExists(userHistory.UserHid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserHistory", new { id = userHistory.UserHid }, userHistory);
        }

        // DELETE: api/UserHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserHistory(int id)
        {
            var userHistory = await _context.UserHistories.FindAsync(id);
            if (userHistory == null)
            {
                return NotFound();
            }

            _context.UserHistories.Remove(userHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserHistoryExists(int id)
        {
            return _context.UserHistories.Any(e => e.UserHid == id);
        }
    }
}
