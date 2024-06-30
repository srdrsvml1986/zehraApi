using NArchitecture.Core.Application.Responses;

namespace Application.Features.Surveys.Queries.GetById;

public class GetByIdSurveyResponse : IResponse
{
    public Guid Id { get; set; }
    public string Question { get; set; }
    public string AnswerOne { get; set; }
    public string AnswerTwo { get; set; }
    public string AnswerThree { get; set; }
    public int AnswerOneCount { get; set; }
    public int AnswerTwoCount { get; set; }
    public int AnswerThreeCount { get; set; }
}