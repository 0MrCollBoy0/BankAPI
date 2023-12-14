using BankAPI.Contracts.Contexts.User;

namespace BankAPI.Contracts.Contexts.Bill;

/// <summary>
/// Модель Счетов
/// </summary>
public class BillDto
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Баланс
    /// </summary>
    public decimal Balance { get; set; }
    
    
    // TODO Добавить контракт Transaction
    // /// <summary>
    // /// Транзакции
    // /// </summary>
    // public IEnumerable<Transaction.Transaction> Transactions { get; set; }
}