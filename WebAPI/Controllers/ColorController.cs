using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetById;
using Application.Features.Color.Commands.Create;
using Application.Features.Color.Commands.Delete;
using Application.Features.Color.Commands.Update;
using Application.Features.Color.Queries.GetAll;
using Application.Features.Color.Queries.GetById;
using Application.Repositories.Abstract;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Persistence.Repositories.Concrete;
using System.Drawing;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IMediator mediator;

        public ColorController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateColorCommand color)
        {
            CreateColorResponse? response = await mediator.Send(color);
            return Created("", response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            {
                DeleteColorCommand deleteCommand = new DeleteColorCommand() { Id = id };
                var response = await mediator.Send(deleteCommand);
                return Ok(response);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateColorCommand updateColorCommand)
        {
            var updatedCommand = await mediator.Send(updateColorCommand);
            return Ok(updatedCommand);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllColorQuery getAllColorQuery = new GetAllColorQuery();
            var response = mediator.Send(getAllColorQuery);
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetByIdColorQuery query = new GetByIdColorQuery();
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
