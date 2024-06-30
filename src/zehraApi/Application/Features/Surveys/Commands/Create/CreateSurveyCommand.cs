using Application.Features.Surveys.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Surveys.Commands.Create;

public class CreateSurveyCommand : IRequest<CreatedSurveyResponse>
{
    public required string Question { get; set; }
    public required string AnswerOne { get; set; }
    public required string AnswerTwo { get; set; }
    public required string AnswerThree { get; set; }
    public required int AnswerOneCount { get; set; }
    public required int AnswerTwoCount { get; set; }
    public required int AnswerThreeCount { get; set; }

    public class CreateSurveyCommandHandler : IRequestHandler<CreateSurveyCommand, CreatedSurveyResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISurveyRepository _surveyRepository;
        private readonly SurveyBusinessRules _surveyBusinessRules;

        public CreateSurveyCommandHandler(IMapper mapper, ISurveyRepository surveyRepository,
                                         SurveyBusinessRules surveyBusinessRules)
        {
            _mapper = mapper;
            _surveyRepository = surveyRepository;
            _surveyBusinessRules = surveyBusinessRules;
        }

        public async Task<CreatedSurveyResponse> Handle(CreateSurveyCommand request, CancellationToken cancellationToken)
        {
            Survey survey = _mapper.Map<Survey>(request);

            await _surveyRepository.AddAsync(survey);

            CreatedSurveyResponse response = _mapper.Map<CreatedSurveyResponse>(survey);
            return response;
        }
    }
}