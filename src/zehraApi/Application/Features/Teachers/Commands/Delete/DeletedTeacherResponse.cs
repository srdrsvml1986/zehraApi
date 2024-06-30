using NArchitecture.Core.Application.Responses;

namespace Application.Features.Teachers.Commands.Delete;

public class DeletedTeacherResponse : IResponse
{
    public Guid Id { get; set; }
}