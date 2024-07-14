using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetAll;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Fuel.Commands.Create;
using Application.Features.Fuel.Commands.Delete;
using Application.Features.Fuel.Commands.Update;
using Application.Features.Fuel.Queries.GetAll;
using Application.Features.Fuel.Queries.GetById;
using Application.Repositories.Abstract;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelController : ControllerBase
    {
        private readonly IMediator mediator;

        public FuelController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateFuelCommand createFuelCommand)
        {
            var response = await mediator.Send(createFuelCommand);
            return Created("", response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            DeleteFuelCommand deleteCommand = new DeleteFuelCommand() { Id = Id };
            var response = await mediator.Send(deleteCommand);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateFuelCommand updateFuelCommand)
        {
            var updatedCommand = await mediator.Send(updateFuelCommand);
            return Ok(updatedCommand);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllFuelQuery query = new GetAllFuelQuery();
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            GetByIdFuelQuery query = new GetByIdFuelQuery();
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
