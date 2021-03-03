using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Data
{
    public abstract class Entity
    {

        public const string CoreSchema = "ToDoApp";

        public string Id { get; set; }
        
    }

    public abstract class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Entity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NEWID()")
                .HasMaxLength(36)
                .IsUnicode(false);
        }
    }
}


