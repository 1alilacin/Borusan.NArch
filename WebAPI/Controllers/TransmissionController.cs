using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetAll;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Transmission.Commands.Create;
using Application.Features.Transmission.Commands.Delete;
using Application.Features.Transmission.Commands.Update;
using Application.Features.Transmission.Queries.GetAll;
using Application.Features.Transmission.Queries.GetById;
using Application.Repositories.Abstract;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionController : ControllerBase
    {
        private readonly IMediator mediator;

        public TransmissionController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateTransmissionCommand createTransmissionCommand)
        {
            CreateTransmissionResponse? response = await mediator.Send(createTransmissionCommand);
            return Created("", response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllTransmissionQuery query = new GetAllTransmissionQuery();
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteTransmissionCommand deleteCommand = new DeleteTransmissionCommand() { Id = id };
            var response = await mediator.Send(deleteCommand);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTranmissionCommand updateTranmissionCommand)
        {
            var updatedCommand = await mediator.Send(updateTranmissionCommand);
            return Ok(updatedCommand);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetByIdTransmissionQuery query = new GetByIdTransmissionQuery();
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
