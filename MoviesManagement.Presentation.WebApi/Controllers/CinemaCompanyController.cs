using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviesManagement.Core.Application.DTOs;
using MoviesManagement.Core.Application.Features.CinemaCompanies.Commands;
using MoviesManagement.Core.Application.Features.CinemaCompanies.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesManagement.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemaCompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CinemaCompanyController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        //Get
        [HttpGet]
        public async Task<IEnumerable<GetCinemaCompanyDto>> GetAll() =>
            await _mediator.Send(new GetCinemaCompaniesQuery.Request());

        [HttpGet("{id}")]
        public async Task<GetCinemaCompanyDto> Get([FromRoute] int id) =>
            await _mediator.Send(new GetCinemaCompanyQuery.Request(id));

        //post
        [HttpPost]
        public async Task Post([FromBody] CreateCinemaCompanyCommand.Request request) =>
            await _mediator.Send(request);

        //put
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UpdateCinemaCompanyCommand.Command command)
        {
            command.SetId(id);
            await _mediator.Send(command);
        }

        //delete
        [HttpDelete("{id}")]
        public async Task Delete(int id) =>
            await _mediator.Send(new DeleteCinemaCompanyCommand.Request(id));
    }
}
