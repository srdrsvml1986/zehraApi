using Application.Features.Projects.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Projects.Commands.Create;

public class CreateProjectCommand : IRequest<CreatedProjectResponse>
{
    public required string ProjectName { get; set; }
    public required string ProjectDescription { get; set; }

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, CreatedProjectResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        private readonly ProjectBusinessRules _projectBusinessRules;

        public CreateProjectCommandHandler(IMapper mapper, IProjectRepository projectRepository,
                                         ProjectBusinessRules projectBusinessRules)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
            _projectBusinessRules = projectBusinessRules;
        }

        public async Task<CreatedProjectResponse> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            Project project = _mapper.Map<Project>(request);

            await _projectRepository.AddAsync(project);

            CreatedProjectResponse response = _mapper.Map<CreatedProjectResponse>(project);
            return response;
        }
    }
}