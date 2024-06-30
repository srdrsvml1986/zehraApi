using NArchitecture.Core.Application.Responses;

namespace Application.Features.Teachers.Commands.Update;

public class UpdatedTeacherResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string PhotoURL { get; set; }
}