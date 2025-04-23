using Microsoft.AspNetCore.Mvc.Filters;
using Optix.Movies.Services;
using Optix.Movies.Services.Interfaces;

namespace Optix.Movies.Api
{
    public static class DependencyConfig
    {
        public static void AddMovieServices(this IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();
        }


    }
}
