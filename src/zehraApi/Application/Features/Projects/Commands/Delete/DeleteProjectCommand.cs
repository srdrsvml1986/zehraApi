using Application.Features.Projects.Constants;
using Application.Features.Projects.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Projects.Commands.Delete;

public class DeleteProjectCommand : IRequest<DeletedProjectResponse>
{
    public Guid Id { get; set; }

    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, DeletedProjectResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        private readonly ProjectBusinessRules _projectBusinessRules;

        public DeleteProjectCommandHandler(IMapper mapper, IProjectRepository projectRepository,
                                         ProjectBusinessRules projectBusinessRules)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
            _projectBusinessRules = projectBusinessRules;
        }

        public async Task<DeletedProjectResponse> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            Project? project = await _projectRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _projectBusinessRules.ProjectShouldExistWhenSelected(project);

            await _projectRepository.DeleteAsync(project!);

            DeletedProjectResponse response = _mapper.Map<DeletedProjectResponse>(project);
            return response;
        }
    }
}