using NArchitecture.Core.Application.Responses;

namespace Application.Features.Projects.Commands.Update;

public class UpdatedProjectResponse : IResponse
{
    public Guid Id { get; set; }
    public string ProjectName { get; set; }
    public string ProjectDescription { get; set; }
}