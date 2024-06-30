using Application.Features.Teachers.Constants;
using Application.Features.Teachers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teachers.Commands.Delete;

public class DeleteTeacherCommand : IRequest<DeletedTeacherResponse>
{
    public Guid Id { get; set; }

    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, DeletedTeacherResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITeacherRepository _teacherRepository;
        private readonly TeacherBusinessRules _teacherBusinessRules;

        public DeleteTeacherCommandHandler(IMapper mapper, ITeacherRepository teacherRepository,
                                         TeacherBusinessRules teacherBusinessRules)
        {
            _mapper = mapper;
            _teacherRepository = teacherRepository;
            _teacherBusinessRules = teacherBusinessRules;
        }

        public async Task<DeletedTeacherResponse> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher? teacher = await _teacherRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _teacherBusinessRules.TeacherShouldExistWhenSelected(teacher);

            await _teacherRepository.DeleteAsync(teacher!);

            DeletedTeacherResponse response = _mapper.Map<DeletedTeacherResponse>(teacher);
            return response;
        }
    }
}