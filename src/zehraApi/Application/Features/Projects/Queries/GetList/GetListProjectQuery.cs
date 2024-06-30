using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Projects.Queries.GetList;

public class GetListProjectQuery : IRequest<GetListResponse<GetListProjectListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListProjectQueryHandler : IRequestHandler<GetListProjectQuery, GetListResponse<GetListProjectListItemDto>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public GetListProjectQueryHandler(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProjectListItemDto>> Handle(GetListProjectQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Project> projects = await _projectRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProjectListItemDto> response = _mapper.Map<GetListResponse<GetListProjectListItemDto>>(projects);
            return response;
        }
    }
}