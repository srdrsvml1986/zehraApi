using Application.Features.Teachers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Teachers.Commands.Create;

public class CreateTeacherCommand : IRequest<CreatedTeacherResponse>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string PhotoURL { get; set; }

    public class CreateTeacherCommandHandler : IRequestHandler<CreateTeacherCommand, CreatedTeacherResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITeacherRepository _teacherRepository;
        private readonly TeacherBusinessRules _teacherBusinessRules;

        public CreateTeacherCommandHandler(IMapper mapper, ITeacherRepository teacherRepository,
                                         TeacherBusinessRules teacherBusinessRules)
        {
            _mapper = mapper;
            _teacherRepository = teacherRepository;
            _teacherBusinessRules = teacherBusinessRules;
        }

        public async Task<CreatedTeacherResponse> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher teacher = _mapper.Map<Teacher>(request);

            await _teacherRepository.AddAsync(teacher);

            CreatedTeacherResponse response = _mapper.Map<CreatedTeacherResponse>(teacher);
            return response;
        }
    }
}