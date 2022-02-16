using Hackathon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hackathon.Persistence.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(nameof(Employee));
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.Id).HasColumnName("EmployeeId");
            builder.Property(e => e.Name).HasMaxLength(64);
            builder.Property(e => e.NIF).HasMaxLength(9);
            builder.Property(e => e.Email).HasMaxLength(64);

           

            builder.OwnsOne(e => e.Address, 
                adr =>
                {
                    adr.Property(p => p.Line1).HasMaxLength(64);
                    adr.Property(p => p.Line2).HasMaxLength(64);
                    adr.Property(p => p.City).HasMaxLength(64);
                    adr.Property(p => p.State).HasMaxLength(64);
                    adr.Property(p => p.PostalCode).HasMaxLength(16);
                });

            builder.HasData(new Employee { 
                Id = new Guid("e978e7ac-ccb7-47dc-91e5-d83cf381ddcc"), 
                Email = "fajb_developer@gmail.com", 
                NIF = "267924607", 
                Name = "Fábio" 
            });

            builder.OwnsOne(e => e.Address).HasData(new
            {
                EmployeeId = new Guid("e978e7ac-ccb7-47dc-91e5-d83cf381ddcc"),
                Line1 = "Rua1",
                Line2 = "Rua2",
                City = "Sintra",
                State = "Lisboa",
                PostalCode = "2715"
            });
        }
    }
}