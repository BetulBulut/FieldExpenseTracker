using FieldExpenseTracker.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FieldExpenseTracker.Data.Configurations
{
    public class EmployeePhoneConfiguration : IEntityTypeConfiguration<EmployeePhone>
    {
        public void Configure(EntityTypeBuilder<EmployeePhone> builder)
        {
            builder.ToTable("EmployeePhones");
            builder.HasKey(ep => ep.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(ep => ep.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15); 
            builder.Property(ep => ep.IsDefault)
                .IsRequired();
        }
    }
}