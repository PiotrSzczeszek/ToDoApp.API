using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using ToDoApp.Data;
using ToDoApp.Data.Entities;

namespace RolePlayManager.Api.Data.Entities
{
    public class RefreshToken : Entity
    {
        public string Token { get; set; }
        public DateTime ValidUntil { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }

    internal class RefreshTokenConfiguration : EntityConfiguration<RefreshToken>
    {
        public override void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            base.Configure(builder);

            builder.ToTable("RefreshToken", Entity.CoreSchema);

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.RefreshTokens)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(e => e.UserId);

            builder.Property(e => e.Token)
                .HasColumnName("Token")
                .IsRequired()
                .HasMaxLength(32)
                .IsUnicode(false);

            builder.Property(e => e.ValidUntil)
                .HasColumnName("ValidUntil")
                .IsRequired();
        }
    }
}
