namespace BankAPI.Domain.Transaction;

/// <summary>
/// Транзакция
/// </summary>
public class Transaction
{
    /// <summary>
    /// Идентификатор отправителя
    /// </summary>
    public Guid SenderId { get; set; }
    
    /// <summary>
    /// Отправитель
    /// </summary>
    public Bill.Bill Sender { get; set; }
    
    /// <summary>
    /// Идентификатор получателя
    /// </summary>
    public Guid ReceiverId { get; set; }
    
    /// <summary>
    /// Получатель
    /// </summary>
    public Bill.Bill Receiver { get; set; }
    
    /// <summary>
    /// Дата совершения транзакции
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// Сумма
    /// </summary>
    public decimal Sum { get; set; }
}