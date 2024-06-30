using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Teachers.Queries.GetList;

public class GetListTeacherQuery : IRequest<GetListResponse<GetListTeacherListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListTeacherQueryHandler : IRequestHandler<GetListTeacherQuery, GetListResponse<GetListTeacherListItemDto>>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public GetListTeacherQueryHandler(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTeacherListItemDto>> Handle(GetListTeacherQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Teacher> teachers = await _teacherRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTeacherListItemDto> response = _mapper.Map<GetListResponse<GetListTeacherListItemDto>>(teachers);
            return response;
        }
    }
}