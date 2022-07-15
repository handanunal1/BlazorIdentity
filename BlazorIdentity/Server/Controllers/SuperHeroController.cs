using BlazorIdentity.Server.Data;
using BlazorIdentity.Server.Models;
using BlazorIdentity.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlazorIdentity.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SuperHeroController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes()
        {
            var user = await _context.Users
                .Include(u => u.SuperHeroes).FirstOrDefaultAsync(u => u.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user.SuperHeroes);
        }
    }
}
