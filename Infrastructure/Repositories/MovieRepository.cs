using ApplicationCore.Entities;
using ApplicationCore.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Infrastructure.Repositories;

public class MovieRepository : BaseRepository<Movie>, IMovieRepository
{
    public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
    {
        
    }

    public IEnumerable<Movie> GetTop20GrossingMovies()
    {
        var movies = _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(20);
        return movies;
    }
    
}