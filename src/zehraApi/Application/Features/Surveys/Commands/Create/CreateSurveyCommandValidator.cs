using FluentValidation;

namespace Application.Features.Surveys.Commands.Create;

public class CreateSurveyCommandValidator : AbstractValidator<CreateSurveyCommand>
{
    public CreateSurveyCommandValidator()
    {
        RuleFor(c => c.Question).NotEmpty();
        RuleFor(c => c.AnswerOne).NotEmpty();
        RuleFor(c => c.AnswerTwo).NotEmpty();
        RuleFor(c => c.AnswerThree).NotEmpty();
        RuleFor(c => c.AnswerOneCount).NotEmpty();
        RuleFor(c => c.AnswerTwoCount).NotEmpty();
        RuleFor(c => c.AnswerThreeCount).NotEmpty();
    }
}