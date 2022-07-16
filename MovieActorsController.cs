using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeltaX_WebApp.Data;
using DeltaX_WebApp.Models;

namespace DeltaX_WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieActorsController : ControllerBase
    {
        private readonly DeltaX_WebAppContext _context;

        public MovieActorsController(DeltaX_WebAppContext context)
        {
            _context = context;
        }

        // GET: api/MovieActors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieActor>>> GetMovieActor()
        {
            return await _context.MovieActor.ToListAsync();
        }

        // GET: api/MovieActors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieActor>> GetMovieActor(string id)
        {
            var movieActor = await _context.MovieActor.FindAsync(id);

            if (movieActor == null)
            {
                return NotFound();
            }

            return movieActor;
        }

        // PUT: api/MovieActors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieActor(string id, MovieActor movieActor)
        {
            if (id != movieActor.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(movieActor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieActorExists(id))
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

        // POST: api/MovieActors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MovieActor>> PostMovieActor(MovieActor movieActor)
        {
            _context.MovieActor.Add(movieActor);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovieActorExists(movieActor.MovieId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovieActor", new { id = movieActor.MovieId }, movieActor);
        }

        // DELETE: api/MovieActors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MovieActor>> DeleteMovieActor(string id)
        {
            var movieActor = await _context.MovieActor.FindAsync(id);
            if (movieActor == null)
            {
                return NotFound();
            }

            _context.MovieActor.Remove(movieActor);
            await _context.SaveChangesAsync();

            return movieActor;
        }

        private bool MovieActorExists(string id)
        {
            return _context.MovieActor.Any(e => e.MovieId == id);
        }
    }
}
