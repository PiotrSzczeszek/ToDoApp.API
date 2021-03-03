using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Data.Entities
{
    public class ToDo : Entity
    {
        public string Title { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DueDate { get; set; }
        public ICollection<Task> Tasks { get; set; }

    }

    public class ToDoConfiguration : EntityConfiguration<ToDo>
    {
        public override void Configure(EntityTypeBuilder<ToDo> builder)
        {
            base.Configure(builder);

            builder.ToTable("ToDo", Entity.CoreSchema);

            builder.Property(e => e.Title)
                .HasColumnName("Title")
                .IsRequired(true)
                .IsUnicode(false)
                .HasMaxLength(100);

            builder.HasOne(e => e.User);

            builder.HasMany(e => e.Tasks)
                .WithOne(e => e.ToDo)
                .HasForeignKey(e => e.ToDoId);

        }
    }
}
