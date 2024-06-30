using Application.Features.Projects.Commands.Create;
using Application.Features.Projects.Commands.Delete;
using Application.Features.Projects.Commands.Update;
using Application.Features.Projects.Queries.GetById;
using Application.Features.Projects.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedProjectResponse>> Add([FromBody] CreateProjectCommand command)
    {
        CreatedProjectResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedProjectResponse>> Update([FromBody] UpdateProjectCommand command)
    {
        UpdatedProjectResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedProjectResponse>> Delete([FromRoute] Guid id)
    {
        DeleteProjectCommand command = new() { Id = id };

        DeletedProjectResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdProjectResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdProjectQuery query = new() { Id = id };

        GetByIdProjectResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListProjectQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProjectQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListProjectListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}