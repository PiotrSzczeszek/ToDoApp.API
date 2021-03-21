using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Data.Entities
{
    public class Task : Entity
    {
        public string TaskContent { get; set; }
        public bool IsFinished { get; set; }
        public ToDo ToDo { get; set; }
        public string ToDoId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class TaskConfiguration : EntityConfiguration<Task>
    {
        public override void Configure(EntityTypeBuilder<Task> builder)
        {
            base.Configure(builder);
            builder.ToTable("Task", Entity.CoreSchema);

            builder.Property(e => e.TaskContent)
                .HasColumnName("Active")
                .IsRequired(true);

            builder.Property(e => e.IsFinished)
                .HasColumnName("IsFinished")
                .HasDefaultValue(false);

            builder.HasOne(e => e.ToDo)
                .WithMany()
                .HasForeignKey(e => e.ToDoId)
                .IsRequired();

        }
    }
}
