using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab3;
using Lab3.Models;

namespace Lab3.Controllers
{
    public class MovieGenresController : Controller
    {
        private readonly ApplicationContext _context;

        public MovieGenresController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: MovieGenres
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.MovieGenres.Include(m => m.Genre).Include(m => m.Movie);
            return View(await applicationContext.ToListAsync());
        }

        // GET: MovieGenres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieGenre = await _context.MovieGenres
                .Include(m => m.Genre)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieGenre == null)
            {
                return NotFound();
            }

            return View(movieGenre);
        }

        // GET: MovieGenres/Create
        public IActionResult Create()
        {
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id");
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,GenreId")] MovieGenre movieGenre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieGenre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id", movieGenre.GenreId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", movieGenre.MovieId);
            return View(movieGenre);
        }

        // GET: MovieGenres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieGenre = await _context.MovieGenres.FindAsync(id);
            if (movieGenre == null)
            {
                return NotFound();
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id", movieGenre.GenreId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", movieGenre.MovieId);
            return View(movieGenre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieId,GenreId")] MovieGenre movieGenre)
        {
            if (id != movieGenre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieGenre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieGenreExists(movieGenre.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Id", movieGenre.GenreId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", movieGenre.MovieId);
            return View(movieGenre);
        }

        // GET: MovieGenres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieGenre = await _context.MovieGenres
                .Include(m => m.Genre)
                .Include(m => m.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieGenre == null)
            {
                return NotFound();
            }

            return View(movieGenre);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movieGenre = await _context.MovieGenres.FindAsync(id);
            if (movieGenre != null)
            {
                _context.MovieGenres.Remove(movieGenre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieGenreExists(int id)
        {
            return _context.MovieGenres.Any(e => e.Id == id);
        }
    }
}
