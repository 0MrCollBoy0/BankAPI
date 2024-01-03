using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAPI.Infrastructure.DataAccess.Contexts.Bill.Configurations;

public class BillConfiguration : IEntityTypeConfiguration<Domain.Bill.Bill>
{
    public void Configure(EntityTypeBuilder<Domain.Bill.Bill> builder)
    {
        builder.HasKey(e => e.Id);

        // builder
        //     .HasMany(b => b.Transactions)
        //     .WithOne(t => t.Sender)
        //     .HasForeignKey(t => t.SenderId)
        //     .OnDelete(DeleteBehavior.Cascade)
        //     .IsRequired(false);
        //
        // builder
        //     .HasMany(b => b.Transactions)
        //     .WithOne(t => t.Receiver)
        //     .HasForeignKey(t => t.ReceiverId)
        //     .OnDelete(DeleteBehavior.Cascade)
        //     .IsRequired(false);

        builder
            .HasOne(b => b.User)
            .WithMany(u => u.Bills)
            .HasForeignKey(b => b.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(true);
    }
}