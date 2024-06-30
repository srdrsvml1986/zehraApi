using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Surveys.Queries.GetList;

public class GetListSurveyListItemDto : IDto
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