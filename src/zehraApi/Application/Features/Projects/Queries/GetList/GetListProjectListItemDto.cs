using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Projects.Queries.GetList;

public class GetListProjectListItemDto : IDto
{
    public Guid Id { get; set; }
    public string ProjectName { get; set; }
    public string ProjectDescription { get; set; }
}