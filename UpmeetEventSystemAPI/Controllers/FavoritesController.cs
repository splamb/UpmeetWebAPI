using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UpmeetEventSystemAPI.Data;
using UpmeetEventSystemAPI.Models;

namespace UpmeetEventSystemAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly UpmeetEventSystemAPIContext _context;

        public FavoritesController(UpmeetEventSystemAPIContext context)
        {
            _context = context;
        }

        // GET: api/Favorites/list
        // Lists out favorites for that user
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> ListFavorites(string username)
        {
            var favorites = await _context.Favorite.ToListAsync();
            var uniqueFavorites = new List<Favorite>();
            foreach(Favorite favorite in favorites)
            {
                if (favorite.Username == username)
                {
                    uniqueFavorites.Add(favorite);
                }
            }
            var result = new OkObjectResult(uniqueFavorites);
            return result;
        }

        // POST: api/Favorites
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Route("add")]
        [HttpPost]
        public async Task<ActionResult<Favorite>> AddFavorite([Bind("FavoriteID,EventID,Username")] Favorite favorite)
        {
            await _context.Favorite.AddAsync(favorite);
            await _context.SaveChangesAsync();

            var result = new OkObjectResult(favorite);

            return result;
        }

        // DELETE: api/Favorites/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Favorite>> DeleteFavorite(int id)
        {
            var favorites = await _context.Favorite.ToListAsync();
            foreach(Favorite favorite in favorites)
            {
                if (favorite.FavoriteID == id)
                {
                    _context.Favorite.Remove(favorite);
                    await _context.SaveChangesAsync();
                }
            }
            var result = new OkResult();
            return result;
        }

        private bool FavoriteExists(int id)
        {
            return _context.Favorite.Any(e => e.FavoriteID == id);
        }
    }
}
