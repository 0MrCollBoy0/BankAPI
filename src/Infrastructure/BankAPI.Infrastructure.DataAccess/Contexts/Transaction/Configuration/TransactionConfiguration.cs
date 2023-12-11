using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAPI.Infrastructure.DataAccess.Contexts.Transaction.Configuration;

public class TransactionConfiguration : IEntityTypeConfiguration<Domain.Transaction.Transaction>
{
    public void Configure(EntityTypeBuilder<Domain.Transaction.Transaction> builder)
    {
        builder.HasKey(t => new { t.ReceiverId, t.SenderId, t.CreatedAt });

        builder
            .HasOne(t => t.Receiver)
            .WithMany()
            .HasForeignKey(t => t.ReceiverId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        
        builder
            .HasOne(t => t.Sender)
            .WithMany()
            .HasForeignKey(t => t.SenderId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}