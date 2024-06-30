using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ITeacherRepository : IAsyncRepository<Teacher, Guid>, IRepository<Teacher, Guid>
{
}