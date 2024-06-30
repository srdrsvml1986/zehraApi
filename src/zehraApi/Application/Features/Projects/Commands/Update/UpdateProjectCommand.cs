using Application.Features.Projects.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Projects.Commands.Update;

public class UpdateProjectCommand : IRequest<UpdatedProjectResponse>
{
    public Guid Id { get; set; }
    public required string ProjectName { get; set; }
    public required string ProjectDescription { get; set; }

    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, UpdatedProjectResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        private readonly ProjectBusinessRules _projectBusinessRules;

        public UpdateProjectCommandHandler(IMapper mapper, IProjectRepository projectRepository,
                                         ProjectBusinessRules projectBusinessRules)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
            _projectBusinessRules = projectBusinessRules;
        }

        public async Task<UpdatedProjectResponse> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            Project? project = await _projectRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _projectBusinessRules.ProjectShouldExistWhenSelected(project);
            project = _mapper.Map(request, project);

            await _projectRepository.UpdateAsync(project!);

            UpdatedProjectResponse response = _mapper.Map<UpdatedProjectResponse>(project);
            return response;
        }
    }
}