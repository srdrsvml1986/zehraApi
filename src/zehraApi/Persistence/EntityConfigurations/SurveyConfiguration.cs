using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
{
    public void Configure(EntityTypeBuilder<Survey> builder)
    {
        builder.ToTable("Surveys").HasKey(s => s.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.Question).HasColumnName("Question").IsRequired();
        builder.Property(s => s.AnswerOne).HasColumnName("AnswerOne").IsRequired();
        builder.Property(s => s.AnswerTwo).HasColumnName("AnswerTwo").IsRequired();
        builder.Property(s => s.AnswerThree).HasColumnName("AnswerThree").IsRequired();
        builder.Property(s => s.AnswerOneCount).HasColumnName("AnswerOneCount").IsRequired();
        builder.Property(s => s.AnswerTwoCount).HasColumnName("AnswerTwoCount").IsRequired();
        builder.Property(s => s.AnswerThreeCount).HasColumnName("AnswerThreeCount").IsRequired();
        builder.Property(s => s.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(s => s.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(s => s.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
    }
}