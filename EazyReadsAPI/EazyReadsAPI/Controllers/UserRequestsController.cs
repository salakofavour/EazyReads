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
    public class UserRequestsController : ControllerBase
    {
        private readonly EazyReadsContext _context = new EazyReadsContext();

        /*public UserRequestsController(EazyReadsContext context)
        {
            _context = context;
        }*/

        // GET: api/UserRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRequest>>> GetUserRequests()
        {
            return await _context.UserRequests.ToListAsync();
        }

        // GET: api/UserRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRequest>> GetUserRequest(int id)
        {
            var userRequest = await _context.UserRequests.FindAsync(id);

            if (userRequest == null)
            {
                return NotFound();
            }

            return userRequest;
        }

        // PUT: api/UserRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRequest(int id, UserRequest userRequest)
        {
            if (id != userRequest.UserRid)
            {
                return BadRequest();
            }

            _context.Entry(userRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRequestExists(id))
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

        // POST: api/UserRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRequest>> PostUserRequest(UserRequest userRequest)
        {
            _context.UserRequests.Add(userRequest);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserRequestExists(userRequest.UserRid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserRequest", new { id = userRequest.UserRid }, userRequest);
        }

        // DELETE: api/UserRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRequest(int id)
        {
            var userRequest = await _context.UserRequests.FindAsync(id);
            if (userRequest == null)
            {
                return NotFound();
            }

            _context.UserRequests.Remove(userRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserRequestExists(int id)
        {
            return _context.UserRequests.Any(e => e.UserRid == id);
        }
    }
}
