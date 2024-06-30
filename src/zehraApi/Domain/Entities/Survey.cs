using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class Survey : Entity<Guid>
{
    public string Question { get; set; }
    public string AnswerOne { get; set; }
    public string AnswerTwo { get; set; }
    public required string AnswerThree { get; set; } 
    public int AnswerOneCount { get; set; }
    public int AnswerTwoCount { get; set; }
    public int AnswerThreeCount { get; set; }



}
