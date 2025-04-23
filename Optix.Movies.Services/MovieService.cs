using Microsoft.Extensions.Logging;
using data = Optix.Movies.Data;
using Optix.Movies.Objects;
using Optix.Movies.Services.Interfaces;
using Optix.Movies.DomainModels;
using Optix.Movies.Objects.Enums;
using Optix.Movies.Services.Extensions;
using System;

namespace Optix.Movies.Services
{
    public class MovieService : data.MovieContextBase, IMovieService
    {
        public MovieService(data.MovieContext context, ILogger<MovieService> logger) : base(context, logger)
        {
        }

        public async Task<ResultItem<List<MovieDetail>>> GetMovies()
        {
            try
            {
                var movies = _db.MovieDetails.AllMatch()?.ToList();

                var movieItems = movies!.ToMovieDetail().ToList();

                return await Task.FromResult(new ResultItem<List<MovieDetail>>(movieItems));
            }
            catch (Exception exception)
            {
                return await Task.FromResult(new ResultItem<List<MovieDetail>>(null!, ErrorStatusType.Exception, $"{exception.Message}"));
            }
        }
        public async Task<ResultItem<List<MovieDetail>>> GetMoviesByGenre(string genre)
        {
            try
            {
                var movies = _db.MovieDetails.Where(movie => movie.Genre!.Equals(genre))?.ToList();

                if (movies == null || movies.Count() == default(int))
                    await Task.FromResult(new ResultItem<List<MovieDetail>>(null!, ErrorStatusType.NotFound, $"{genre} is not found in the list of movies"));

                return await Task.FromResult(new ResultItem<List<MovieDetail>>(movies!.ToMovieDetail()));
            }
            catch (Exception exception)
            {
                return await Task.FromResult(new ResultItem<List<MovieDetail>>(null!, ErrorStatusType.Exception, $"{exception.Message}"));
            }
        }
        public async Task<ResultItem<List<MovieDetail>>> GetQuery(string paramter)
        {
            if (string.IsNullOrEmpty(paramter))
                await Task.FromResult(new ResultItem<List<MovieDetail>>(null!, ErrorStatusType.NotManaged, $"Paramer is null or empty"));

            DateTime dateTime;
            bool valid = DateTime.TryParse(paramter, out dateTime);

            List<data.MovieDetail> queryable = null!;


            try
            {

                if (valid)
                    queryable = _db.MovieDetails.Where(movie => movie.Release_Date == dateTime).ToList();
                else
                    queryable = _db.MovieDetails.Where(movie => movie.Genre!.Equals(paramter)).ToList();

                if (queryable == null || queryable.Count() == default(int))
                    await Task.FromResult(new ResultItem<List<MovieDetail>>(null!, ErrorStatusType.NotFound, $"not found in the list of movies"));

                return await Task.FromResult(new ResultItem<List<MovieDetail>>(queryable!.ToMovieDetail()));
            }
            catch (Exception exception)
            {
                return await Task.FromResult(new ResultItem<List<MovieDetail>>(null!, ErrorStatusType.Exception, $"{exception.Message}"));
            }
        }
        public async Task<ResultItem<List<MovieDetail>>> GetQuery(int year)
        {
            if (year == default(int))
                await Task.FromResult(new ResultItem<List<MovieDetail>>(null!, ErrorStatusType.NotManaged, $"Paramer is null or empty"));

            List<data.MovieDetail> queryable = null!;


            try
            {

                queryable = _db.MovieDetails.Where(movie => movie.Release_Date!.Value.Year == year).ToList();

                if (queryable == null || queryable.Count() == default(int))
                    await Task.FromResult(new ResultItem<List<MovieDetail>>(null!, ErrorStatusType.NotFound, $"not found in the list of movies"));

                return await Task.FromResult(new ResultItem<List<MovieDetail>>(queryable!.ToMovieDetail()));
            }
            catch (Exception exception)
            {
                return await Task.FromResult(new ResultItem<List<MovieDetail>>(null!, ErrorStatusType.Exception, $"{exception.Message}"));
            }
        }

    }
}
