
using BankAPI.Contracts.Contexts.Transaction;
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
    /// Пользователь
    /// </summary>
    public ShortUserDto User { get; set; }

    /// <summary>
    /// Баланс
    /// </summary>
    public decimal Balance { get; set; }

    /// <summary>
    /// Транзакции
    /// </summary>
    public List<TransactionDto> Transactions { get; set; }
    
}