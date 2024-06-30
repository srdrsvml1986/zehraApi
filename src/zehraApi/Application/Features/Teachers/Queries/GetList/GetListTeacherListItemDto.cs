using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Teachers.Queries.GetList;

public class GetListTeacherListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PhotoURL { get; set; }
}