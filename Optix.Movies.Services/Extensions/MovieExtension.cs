using data = Optix.Movies.Data;
using Optix.Movies.DomainModels;

namespace Optix.Movies.Services.Extensions
{
    public static class MovieExtension
    {
        public static MovieDetail ToMovieDetail(this data.MovieDetail movieDetail)
        {
            if (movieDetail == null)
                return null!;

            var movie = new MovieDetail
            {
                Genre = movieDetail.Genre,
                Original_Language = movieDetail.Original_Language,
                Overview = movieDetail.Overview,
                Popularity = movieDetail.Popularity,
                Poster_Url = movieDetail.Poster_Url,
                Release_Date = movieDetail.Release_Date,
                Title = movieDetail.Title,
                Vote_Average = movieDetail.Vote_Average,
                Vote_Count = movieDetail.Vote_Count,

            };

            return movie;
        }

        public static List<MovieDetail> ToMovieDetail(this List<data.MovieDetail> movieDetails)
        {
            if (movieDetails == null || movieDetails.Count  == default(int))
                return new List<MovieDetail>();

            var movies = movieDetails.Select(c=> c.ToMovieDetail()).ToList();
            return movies;
        }

        public static IQueryable<MovieDetail> ToMovieDetail(this IQueryable<data.MovieDetail> movieDetails)
        {
            if (movieDetails == null || movieDetails.Count() == default(int))
                return null!;

            var movies = movieDetails.Select(c => c.ToMovieDetail());
            return movies;
        }

    }
}
