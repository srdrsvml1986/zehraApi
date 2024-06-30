using NArchitecture.Core.Application.Responses;

namespace Application.Features.Projects.Queries.GetById;

public class GetByIdProjectResponse : IResponse
{
    public Guid Id { get; set; }
    public string ProjectName { get; set; }
    public string ProjectDescription { get; set; }
}