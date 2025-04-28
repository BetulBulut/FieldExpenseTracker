using FieldExpenseTracker.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FieldExpenseTracker.Data.Configurations
{
    public class EmployeeIBANConfiguration : IEntityTypeConfiguration<EmployeeIBAN>
    {
        public void Configure(EntityTypeBuilder<EmployeeIBAN> builder)
        {
            builder.ToTable("EmployeeIBANs");
            builder.HasKey(ei => ei.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(ei => ei.IBAN)
                .IsRequired()
                .HasMaxLength(34); 
            builder.Property(ei => ei.IsDefault)
                .IsRequired();
        }
    }
}