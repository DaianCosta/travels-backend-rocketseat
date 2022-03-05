using System;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Models;
using Api.Repositories;
using AutoMapper;

//CONTROLLER
namespace Api.Controllers
{
    [ApiController]
    [Route("travels")]
    [EnableCors("AllowOrigin")]
    public class TravelController : ControllerBase
    {
        private readonly ILogger<TravelController> _logger;
        private readonly IMapper _mapper;
        private readonly ITravelRepository _repository;

        private const string MSG_ERRO_500 = "An unexpected error has occurred";

        public TravelController(ILogger<TravelController> logger
            , ITravelRepository repository
            , IMapper mapper)
        {
            _logger = logger;

            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));

            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }


        /// <summary>
        /// Check all trips
        /// </summary>
        /// <param name="page">Represents the query page</param>
        /// <param name="limit">Represents the maximum number of elements in a query</param>
        /// <param name="nome">Represents the travel destination</param>
        /// <response code="200">Return to travel list</response>
        /// <response code="204">Returns when there are no trips</response>
        /// <response code="400">Returns when there was a malformed request</response>
        /// <response code="500">Returns when there was an internal error</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTravelMetadata))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ReturnError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ReturnError))]
        [Produces("application/json")]
        public IActionResult GetAll(string destiny, int? page = 1, int? limit = 10)
        {
            try
            {
                var travels = _repository.GetAll(page.GetValueOrDefault(), (limit ?? 10), destiny);

                if (travels.Items.Count <= 0)
                    return new NoContentResult();

                return new OkObjectResult(_mapper.Map<GetTravelMetadata>(travels));
            }
            catch (ArgumentException ex)
            {
                return new BadRequestObjectResult(new ReturnError(ex.Message));
            }
            catch (Exception ex)
            {
                _logger?.LogError(MSG_ERRO_500, ex);
                return new JsonResult(500, new ReturnError(MSG_ERRO_500));
            }
        }


        /// <summary>
        /// Check trip details
        /// </summary>
        /// <param name="id">Represents the trip id</param>
        /// <response code="200">Return to travel list</response>
        /// <response code="204">Returns when there are no trips</response>
        /// <response code="400">Returns when there was a malformed request</response>
        /// <response code="500">Returns when there was an internal error</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetTravel))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ReturnError))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ReturnError))]
        [Produces("application/json")]
        public IActionResult Get(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return new BadRequestObjectResult(new ReturnError(string.Join(", ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage))));

                var travel = _repository.Get(id);

                if (travel == null)
                    return new NoContentResult();
                

                return Ok(_mapper.Map<GetTravel>(travel));
            }
            catch (Exception ex)
            {
                _logger?.LogError(MSG_ERRO_500, ex);
                return new JsonResult(500, new ReturnError(MSG_ERRO_500));
            }
        }

    }
}
