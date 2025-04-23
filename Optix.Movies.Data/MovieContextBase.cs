using Microsoft.Extensions.Logging;

namespace Optix.Movies.Data
{
    public  class MovieContextBase
    {
        public readonly MovieContext _context;
        public readonly MoviesRepository _db;
        public readonly ILogger _logger;
        public MovieContextBase(MovieContext context, ILogger logger)
        {
            _context = context;
            _db = new MoviesRepository(context);
            _logger = logger;
        }
    }
}
