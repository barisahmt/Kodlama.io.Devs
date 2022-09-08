using Application.Features.programmingLanguage.Commands.createProgrammingLanguage;
using Application.Features.programmingLanguage.Commands.DeleteProgrammingLanguage;
using Application.Features.programmingLanguage.Commands.UpdateProgrammingLanguage;
using Application.Features.programmingLanguage.Dtos;
using Application.Features.programmingLanguage.Models;
using Application.Features.programmingLanguage.Queries.GetByIdProgrammingLanguage;
using Application.Features.programmingLanguage.Queries.GetListProgrammingLanguage;
using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Dtos;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("", result);
        }
        [HttpDelete("Id")]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeletedProgrammingLanguageDto result = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Ok(result);
        }
        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListBrandQuery = new() { PageRequest = pageRequest };
            ProgrammingLanguageListModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromQuery] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdatedProgrammingLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommand);
            return Ok(result);

        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            GetByIdProgrammingLanguageDto result = await Mediator.Send(getByIdProgrammingLanguageQuery);
            return Ok(result);

        }
        [HttpPost("{id}/technologies")]
        public async Task<IActionResult> AddTechnology([FromRoute] int id,[FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            createTechnologyCommand.ProgrammingLanguageId = id;
            CreatedTechnologyDto result = await Mediator.Send(createTechnologyCommand);
            return Ok(result);

        }

    }
}
 