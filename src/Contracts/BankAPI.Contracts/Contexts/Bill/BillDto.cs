
using BankAPI.Contracts.Contexts.Transaction;

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

    /// <summary>
    /// Транзакции
    /// </summary>
    public IEnumerable<TransactionDto> Transactions { get; set; }
}