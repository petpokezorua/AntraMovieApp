using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Services;

public interface IMovieService
{
    List<MovieCardModel> Top20GrossingMovies();
    MovieDetailsModel GetMovieDetails(int id);
    MovieDetailsModel DeleteMovie(int id);
}