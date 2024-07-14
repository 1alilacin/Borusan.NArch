using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetAll;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Model.Commands.Create;
using Application.Features.Model.Commands.Delete;
using Application.Features.Model.Commands.Update;
using Application.Features.Model.Queries.GetAll;
using Application.Features.Model.Queries.GetById;
using Application.Repositories.Abstract;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IMediator mediator;

        public ModelController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateModelCommand createModelCommand)
        {
            CreateModelResponse? response = await mediator.Send(createModelCommand);
            return Created("", response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllModelQuery query = new GetAllModelQuery();
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteModelCommand deleteCommand = new DeleteModelCommand() { Id = id };
            var response = await mediator.Send(deleteCommand);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateModelCommand updateModelCommand)
        {
            var updatedCommand = await mediator.Send(updateModelCommand);
            return Ok(updatedCommand);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetByIdModelQuery query = new GetByIdModelQuery();
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
