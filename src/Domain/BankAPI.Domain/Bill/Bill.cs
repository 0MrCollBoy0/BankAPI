namespace BankAPI.Domain.Bill;

/// <summary>
/// Счёт
/// </summary>
public class Bill
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Пользователь
    /// </summary>
    public User.User User { get; set; }
    
    /// <summary>
    /// Баланс
    /// </summary>
    public decimal Balance { get; set; }
    
    /// <summary>
    /// Время создания
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// Время последнего редактирования
    /// </summary>
    public DateTime UpdatedAt { get; set; }
    
    /// <summary>
    /// Транзакции
    /// </summary>
    public IEnumerable<Transaction.Transaction> Transactions { get; set; }
}