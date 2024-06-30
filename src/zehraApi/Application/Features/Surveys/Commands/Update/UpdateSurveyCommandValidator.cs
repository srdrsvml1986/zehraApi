using FluentValidation;

namespace Application.Features.Surveys.Commands.Update;

public class UpdateSurveyCommandValidator : AbstractValidator<UpdateSurveyCommand>
{
    public UpdateSurveyCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Question).NotEmpty();
        RuleFor(c => c.AnswerOne).NotEmpty();
        RuleFor(c => c.AnswerTwo).NotEmpty();
        RuleFor(c => c.AnswerThree).NotEmpty();
        RuleFor(c => c.AnswerOneCount).NotEmpty();
        RuleFor(c => c.AnswerTwoCount).NotEmpty();
        RuleFor(c => c.AnswerThreeCount).NotEmpty();
    }
}