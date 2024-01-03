using BankAPI.Contracts.Contexts.Bill;

namespace BankAPI.Contracts.Contexts.Transaction;

/// <summary>
/// Модель Транзакция
/// </summary>
public class TransactionDto
{
    /// <summary>
    /// Отправитель
    /// </summary>
    public BillDto Sender { get; set; }

    /// <summary>
    /// Получатель
    /// </summary>
    public BillDto Receiver { get; set; }
    
    /// <summary>
    /// Дата совершения транзакции
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// Сумма
    /// </summary>
    public decimal Sum { get; set; }
}