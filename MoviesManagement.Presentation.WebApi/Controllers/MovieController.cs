using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviesManagement.Core.Application.DTOs;
using MoviesManagement.Core.Application.Features.Movies.Commands;
using MoviesManagement.Core.Application.Features.Movies.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesManagement.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MovieController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        //Get
        [HttpGet]
        public async Task<IEnumerable<GetMovieDto>> GetAll() =>
            await _mediator.Send(new GetMoviesQuery.Request());

        [HttpGet("{id}")]
        public async Task<GetMovieDto> Get([FromRoute] int id) =>
            await _mediator.Send(new GetMovieQuery.Request(id));

        //Create
        [HttpPost]
        public async Task Post([FromQuery] CreateMovieCommand.Request request) =>
            await _mediator.Send(request);

        //Update
        [HttpPut("{id}")]
        public async Task Update(int id, [FromQuery] UpdateMovieCommand.Request request)
        {
            request.SetId(id);
            await _mediator.Send(request);
        }

        //Delete
        [HttpDelete]
        public async Task Delete(int id) =>
            await _mediator.Send(new DeleteMovieCommand.Request(id));
    }
}
