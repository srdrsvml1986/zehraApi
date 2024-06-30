using Application.Features.Teachers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teachers.Commands.Update;

public class UpdateTeacherCommand : IRequest<UpdatedTeacherResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string PhotoURL { get; set; }

    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand, UpdatedTeacherResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITeacherRepository _teacherRepository;
        private readonly TeacherBusinessRules _teacherBusinessRules;

        public UpdateTeacherCommandHandler(IMapper mapper, ITeacherRepository teacherRepository,
                                         TeacherBusinessRules teacherBusinessRules)
        {
            _mapper = mapper;
            _teacherRepository = teacherRepository;
            _teacherBusinessRules = teacherBusinessRules;
        }

        public async Task<UpdatedTeacherResponse> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher? teacher = await _teacherRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _teacherBusinessRules.TeacherShouldExistWhenSelected(teacher);
            teacher = _mapper.Map(request, teacher);

            await _teacherRepository.UpdateAsync(teacher!);

            UpdatedTeacherResponse response = _mapper.Map<UpdatedTeacherResponse>(teacher);
            return response;
        }
    }
}