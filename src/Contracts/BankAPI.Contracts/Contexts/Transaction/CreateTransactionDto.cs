using BankAPI.Contracts.Contexts.Bill;

namespace BankAPI.Contracts.Contexts.Transaction;

public class CreateTransactionDto
{
    /// <summary>
    /// Получатель
    /// </summary>
    public Guid ReceiverId { get; set; }
    
    /// <summary>
    /// Сумма
    /// </summary>
    public decimal Sum { get; set; }
}