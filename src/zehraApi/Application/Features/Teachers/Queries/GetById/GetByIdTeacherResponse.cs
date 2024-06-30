using NArchitecture.Core.Application.Responses;

namespace Application.Features.Teachers.Queries.GetById;

public class GetByIdTeacherResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PhotoURL { get; set; }
}