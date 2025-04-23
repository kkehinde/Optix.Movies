using Optix.Movies.DomainModels;
using Optix.Movies.Objects;

namespace Optix.Movies.Services.Interfaces
{
    public interface  IMovieService
    {
        Task<ResultItem<List<MovieDetail>>> GetMovies();
        Task<ResultItem<List<MovieDetail>>> GetMoviesByGenre(string genre);
        Task<ResultItem<List<MovieDetail>>> GetQuery(string paramter);
        Task<ResultItem<List<MovieDetail>>> GetQuery(int year);
    }
}
