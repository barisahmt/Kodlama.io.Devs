using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Queries.GetListTechnology;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
    [ApiController]
public class TechnologiesController : Controller
{
    private readonly IMediator _mediator;

    public TechnologiesController(IMediator mediator)
        => _mediator = mediator;


    [HttpPost("add")]
    public async Task<IActionResult> AddTechnology([FromBody] CreateTechnologyCommand createTechnologyCommand )
    {
       
        CreatedTechnologyDto result = await _mediator.Send(createTechnologyCommand);
        return Ok(result);

    }

    [HttpDelete]
    public async Task<IActionResult> Delte([FromBody] DeleteTechnologyCommand deleteTechnologyCommand)
    {
        var result = await _mediator.Send(deleteTechnologyCommand);
        return Ok(result);
    }
    

    [HttpPut("{Id}")]
    public async Task<IActionResult> Update([FromRoute] DeleteTechnologyCommand deleteTechnologyCommand)
    {
        var result = await _mediator.Send(deleteTechnologyCommand);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery]PageRequest pageRequest)
    {
        GetListTechnologyQuery getTechnologyListQuery = new GetListTechnologyQuery(){PageRequest = pageRequest};

        var result = await _mediator.Send(getTechnologyListQuery);

        return Ok(result);
    }
    
}