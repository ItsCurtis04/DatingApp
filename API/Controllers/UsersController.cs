using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")] // api/users

    public class UsersController : ControllerBase
    {

        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet] // API endpoint that get a list of all users from database
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        [HttpGet("{id}")] // Brackets important at it allows api endpoint to read the id from front end.
        public async Task <ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id); // OR return _context.Users.Find(id);

            return user;
        }

    }
}