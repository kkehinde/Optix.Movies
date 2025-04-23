using Microsoft.AspNetCore.Mvc;
using Optix.Movies.Objects.Enums;
using Optix.Movies.Services.Interfaces;
using Optix.Movies.DomainModels;
using Microsoft.AspNetCore.OData.Query;

namespace Optix.Movies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMovieService _movieService;
        public MoviesController(ILogger<MoviesController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        [HttpGet(Name = "ODataService")]
        [EnableQuery(PageSize = 10)]
        public IActionResult Get()
        {
            var resultItem =  _movieService.GetMovies().Result;

            if (resultItem.ErrorStatus != ErrorStatusType.NoError)
                return BadRequest(resultItem.Error?.Message!.ToErrorMessage());

            return Ok(resultItem.Item.AsQueryable());
        }

        [HttpGet("{parameter}")]
        public IActionResult GetGenre(string parameter)
        {
            var resultItem =  _movieService.GetQuery(parameter).Result;

            if (resultItem.ErrorStatus != ErrorStatusType.NoError)
                return BadRequest(resultItem.Error?.Message!.ToErrorMessage());

            return Ok(resultItem.Item.AsQueryable());
        }

        [HttpGet("filter")]
        [EnableQuery(PageSize = 10)]
        public IActionResult FilterByYear(int year)
        {
            var resultItem = _movieService.GetQuery(year).Result;

            if (resultItem.ErrorStatus != ErrorStatusType.NoError)
                return BadRequest(resultItem.Error?.Message!.ToErrorMessage());

            return Ok(resultItem.Item.AsQueryable());
        }
    }
}
