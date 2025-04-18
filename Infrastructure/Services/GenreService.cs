using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class GenreService : IMovieService 
{
    public List<MovieCardModel> Top20GrossingMovies()
    {
        // Grab data.
        var movies = new List<MovieCardModel>() { };
        
        throw new NotImplementedException();
    }

    public MovieDetailsModel GetMovieDetails(int id)
    {
        throw new NotImplementedException();
    }

    public MovieDetailsModel DeleteMovie(int id)
    {
        throw new NotImplementedException();
    }
}