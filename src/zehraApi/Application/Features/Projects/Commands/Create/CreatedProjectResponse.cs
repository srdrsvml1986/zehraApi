using NArchitecture.Core.Application.Responses;

namespace Application.Features.Projects.Commands.Create;

public class CreatedProjectResponse : IResponse
{
    public Guid Id { get; set; }
    public string ProjectName { get; set; }
    public string ProjectDescription { get; set; }
}