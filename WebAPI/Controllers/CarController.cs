using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetAll;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Car.Commands.Create;
using Application.Features.Car.Commands.Delete;
using Application.Features.Car.Commands.Update;
using Application.Features.Car.Queries.GetAll;
using Application.Features.Car.Queries.GetById;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator mediator;

        public CarController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateCarCommand createCarCommand)
        {
            CreateCarResponse? response = await mediator.Send(createCarCommand);
            return Created("", response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllCarQuery query = new GetAllCarQuery();
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteCarCommand deleteCommand = new DeleteCarCommand() { Id = id };
            var response = await mediator.Send(deleteCommand);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCarCommand updateCarCommand)
        {
            var updatedCommand = await mediator.Send(updateCarCommand);
            return Ok(updatedCommand);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetByIdCarQuery query = new GetByIdCarQuery();
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
