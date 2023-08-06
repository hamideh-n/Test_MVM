using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mvm.Core.Domain.Customers.Entities;

namespace Mvm.Infrastructures.Data.SqlServer.Customers.Configs
{
   
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(c => c.Firstname).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Lastname).IsRequired().HasMaxLength(50);
            builder.Property(c => c.DateOfBirth).IsRequired();
            builder.Property(c => c.PhoneNumber).HasColumnType("char").HasMaxLength(11).IsRequired();
            builder.Property(c => c.Email).HasMaxLength(100).IsRequired();
            builder.Property(c => c.BankAccountNumber).HasMaxLength(100).IsRequired();

        }
    }
}
