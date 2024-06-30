using FluentValidation;

namespace Application.Features.Projects.Commands.Update;

public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProjectName).NotEmpty();
        RuleFor(c => c.ProjectDescription).NotEmpty();
    }
}