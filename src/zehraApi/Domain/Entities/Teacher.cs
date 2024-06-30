using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Teacher : Entity<Guid>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string PhotoURL { get; set; }
}
