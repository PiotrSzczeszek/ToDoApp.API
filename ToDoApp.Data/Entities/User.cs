using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp.Data.Entities
{
    public class User : Entity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime AccountCreated { get; set; }
        public bool Active { get; set; }

    }

    public class UserConfiguration : EntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("User", Entity.CoreSchema);

            //Indexes
            builder.HasIndex(e => e.Username)
                .IsUnique();
            
            builder.HasIndex(e => e.Email)
                .IsUnique();

            //Properties
            builder.Property(e => e.Username)
                .HasColumnName("Username")
                .HasMaxLength(40)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasColumnName("Password")
                .IsRequired()
                .HasMaxLength(60)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(70)
                .IsUnicode(false);

            builder.Property(e => e.AccountCreated)
                .HasColumnName("AccountCreated")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.Active)
                .HasColumnName("Active")
                .HasDefaultValue(true);


        }
    }
}
