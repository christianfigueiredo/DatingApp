using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseApiController
    {
        private readonly Contexto _contexto;

        public UserController(Contexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _contexto.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _contexto.Users.FindAsync(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(int id, AppUser user)
        {
            _contexto.Entry(user).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<AppUser>> PostUser(AppUser user)
        {
            _contexto.Users.Add(user);
            await _contexto.SaveChangesAsync();
            return user;
        }
    }
}