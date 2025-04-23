using Optix.Movies.Services;
using Optix.Movies.Services.Interfaces;
using System.Collections.Specialized;

namespace Optix.Movies.Tests
{
    [TestClass]
    public class OptixMoviesTest
    {

        private readonly IMovieService _movieService;
        private readonly NameValueCollection _nameValueCollection;
        public OptixMoviesTest()
        {
            _movieService = new MovieService();
        }

        [TestMethod]
        public async Task Lookup_Movies()
        {
            var result = await _movieService.GetMovies();

            Assert.IsNotNull(result);
        }

    }
}