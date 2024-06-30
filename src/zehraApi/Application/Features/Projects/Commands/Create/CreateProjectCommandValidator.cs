using FluentValidation;

namespace Application.Features.Projects.Commands.Create;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(c => c.ProjectName).NotEmpty();
        RuleFor(c => c.ProjectDescription).NotEmpty();
    }
}