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
    public class UserPaymentInfoesController : ControllerBase
    {
        private readonly EazyReadsContext _context = new EazyReadsContext();

        /*public UserPaymentInfoesController(EazyReadsContext context)
        {
            _context = context;
        }*/

        // GET: api/UserPaymentInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPaymentInfo>>> GetUserPaymentInfos()
        {
            return await _context.UserPaymentInfos.ToListAsync();
        }

        // GET: api/UserPaymentInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPaymentInfo>> GetUserPaymentInfo(int id)
        {
            var userPaymentInfo = await _context.UserPaymentInfos.FindAsync(id);

            if (userPaymentInfo == null)
            {
                return NotFound();
            }

            return userPaymentInfo;
        }

        // PUT: api/UserPaymentInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPaymentInfo(int id, UserPaymentInfo userPaymentInfo)
        {
            if (id != userPaymentInfo.UserPid)
            {
                return BadRequest();
            }

            _context.Entry(userPaymentInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPaymentInfoExists(id))
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

        // POST: api/UserPaymentInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserPaymentInfo>> PostUserPaymentInfo(UserPaymentInfo userPaymentInfo)
        {
            _context.UserPaymentInfos.Add(userPaymentInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserPaymentInfoExists(userPaymentInfo.UserPid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserPaymentInfo", new { id = userPaymentInfo.UserPid }, userPaymentInfo);
        }

        // DELETE: api/UserPaymentInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPaymentInfo(int id)
        {
            var userPaymentInfo = await _context.UserPaymentInfos.FindAsync(id);
            if (userPaymentInfo == null)
            {
                return NotFound();
            }

            _context.UserPaymentInfos.Remove(userPaymentInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserPaymentInfoExists(int id)
        {
            return _context.UserPaymentInfos.Any(e => e.UserPid == id);
        }
    }
}
