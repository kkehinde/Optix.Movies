using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Optix.Movies.Data
{
    public partial  class MoviesRepository: IDisposable
    {
        private readonly MovieContext _context;
        public MoviesRepository(MovieContext context)
        {
            _context = context;
        }

        private GenericRepository<MovieDetail>? _movieDetails;
        public GenericRepository<MovieDetail> MovieDetails
        {
            get
            {
                if (_movieDetails == null)
                    _movieDetails = new GenericRepository<MovieDetail>(_context);

                return _movieDetails;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    _context.Dispose();
            }

            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
