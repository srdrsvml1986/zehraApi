using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Project : Entity<Guid>
{
    public required string ProjectName { get; set; }
    public required string ProjectDescription { get; set; }
}