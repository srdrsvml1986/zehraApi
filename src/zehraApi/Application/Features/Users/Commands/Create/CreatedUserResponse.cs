using NArchitecture.Core.Application.Responses;

namespace Application.Features.Users.Commands.Create;

public class CreatedUserResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
    public string? Photo { get; set; }
    public CreatedUserResponse()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Status = false;
        Photo = string.Empty;
    }

    public CreatedUserResponse(Guid id, string firstName, string lastName, string email, bool status, string? photo)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Status = status;
        Photo = photo;

    }
}
