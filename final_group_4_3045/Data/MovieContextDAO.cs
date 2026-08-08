using Microsoft.EntityFrameworkCore;
using final_group_4_3045.Models;
using final_group_4_3045.Interfaces;

namespace final_group_4_3045.Data
{
    public class MovieDAO: IMovieContextDAO
    {
        private readonly AppDbContext _context;

        public MovieDAO(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie?> GetMovieByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task AddMovieAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            var existingMovie = await _context.Movies.FindAsync(movie.Id);

            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.Genre = movie.Genre;
                existingMovie.ReleaseYear = movie.ReleaseYear;
                existingMovie.Rating = movie.Rating;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteMovieAsync(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }
    }
}