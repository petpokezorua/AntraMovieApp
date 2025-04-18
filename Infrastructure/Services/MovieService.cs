using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }
    
    public List<MovieCardModel> Top20GrossingMovies()
    {
        var movies = _movieRepository.GetTop20GrossingMovies();
        var movieCardModels = new List<MovieCardModel>();
        foreach (var movie in movies)
        {
            movieCardModels.Add(new MovieCardModel()
            {
                Id = movie.Id,
                PosterURL = movie.PosterUrl,
                Title = movie.Title
            });
        }
        return movieCardModels;
    }

    public MovieDetailsModel GetMovieDetails(int id)
    {
        var movie = _movieRepository.GetById(id);
        var movieDetailsModel = new MovieDetailsModel()
        {
            Id = movie.Id,
            Budget = movie.Budget,
            Overview = movie.Overview,
            PosterUrl = movie.PosterUrl,
            Title = movie.Title,
            Revenue = movie.Revenue,
            TagLine = movie.TagLine
        };
        return movieDetailsModel;
    }

    public MovieDetailsModel DeleteMovie(int id)
    {
        var movie = _movieRepository.DeleteById(id);

        if (movie == null)
        {
            return null;
        }
        var movieDetailsModel = new MovieDetailsModel()
        {
            Id = movie.Id,
            Budget = movie.Budget,
            Overview = movie.Overview,
            PosterUrl = movie.PosterUrl,
            Title = movie.Title,
            Revenue = movie.Revenue,
            TagLine = movie.TagLine
        };
        return movieDetailsModel;
    }
}