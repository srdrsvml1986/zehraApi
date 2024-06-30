using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class TeacherRepository : EfRepositoryBase<Teacher, Guid, BaseDbContext>, ITeacherRepository
{
    public TeacherRepository(BaseDbContext context) : base(context)
    {
    }
}