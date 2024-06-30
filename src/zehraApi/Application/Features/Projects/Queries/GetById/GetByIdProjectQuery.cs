using Application.Features.Projects.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Projects.Queries.GetById;

public class GetByIdProjectQuery : IRequest<GetByIdProjectResponse>
{
    public Guid Id { get; set; }

    public class GetByIdProjectQueryHandler : IRequestHandler<GetByIdProjectQuery, GetByIdProjectResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProjectRepository _projectRepository;
        private readonly ProjectBusinessRules _projectBusinessRules;

        public GetByIdProjectQueryHandler(IMapper mapper, IProjectRepository projectRepository, ProjectBusinessRules projectBusinessRules)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
            _projectBusinessRules = projectBusinessRules;
        }

        public async Task<GetByIdProjectResponse> Handle(GetByIdProjectQuery request, CancellationToken cancellationToken)
        {
            Project? project = await _projectRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _projectBusinessRules.ProjectShouldExistWhenSelected(project);

            GetByIdProjectResponse response = _mapper.Map<GetByIdProjectResponse>(project);
            return response;
        }
    }
}