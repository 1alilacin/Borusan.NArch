using Application.Features.Brands.Commands.Create;
using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetAll;
using Application.Features.Brands.Queries.GetById;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IMediator mediator;

        public BrandsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateBrandCommand createBrandCommand)
        {
            CreatedBrandResponse? response = await mediator.Send(createBrandCommand);
            return Created("", response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllBrandsQuery query = new GetAllBrandsQuery();
            var response = await mediator.Send(query);
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            DeleteBrandCommand deleteCommand = new DeleteBrandCommand() { Id = id };
            var response = await mediator.Send(deleteCommand);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBrandCommand updateBrandCommand)
        {
            var updatedCommand = await mediator.Send(updateBrandCommand);
            return Ok(updatedCommand);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetByIdBrandQuery query = new GetByIdBrandQuery();
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
