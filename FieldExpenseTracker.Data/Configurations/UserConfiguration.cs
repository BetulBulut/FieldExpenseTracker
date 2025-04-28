using FieldExpenseTracker.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FieldExpenseTracker.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(300);
            builder.Property(u => u.Secret)
                .HasMaxLength(100);
            builder.Property(u => u.Role)
                .IsRequired()
                .HasConversion<int>();
            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(u => u.OpenDate)
                .IsRequired();
            builder.Property(u => u.LastLoginDate)
                .IsRequired(false); 
        }
    }
}