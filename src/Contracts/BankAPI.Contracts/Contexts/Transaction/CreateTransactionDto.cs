namespace BankAPI.Contracts.Contexts.Transaction;

/// <summary>
/// Модель создания Транзакции
/// </summary>
public class CreateTransactionDto
{
    public Guid SenderId { get; set; }
    
    /// <summary>
    /// Получатель
    /// </summary>
    public Guid ReceiverId { get; set; }
    
    /// <summary>
    /// Сумма
    /// </summary>
    public decimal Sum { get; set; }
}