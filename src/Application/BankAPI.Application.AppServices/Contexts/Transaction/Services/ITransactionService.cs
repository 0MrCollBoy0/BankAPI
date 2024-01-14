using BankAPI.Contracts.Contexts.Transaction;

namespace BankAPI.Application.AppServices.Contexts.Transaction.Services;

/// <summary>
/// Сервис для работы с Транзакциями
/// </summary>
public interface ITransactionService
{
    /// <summary>
    /// Поиск всех Транзакций
    /// </summary>
    /// <param name="senderId"></param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список Транзакций</returns>
    Task<List<TransactionDto>> GetAllByBillAsync(Guid senderId, CancellationToken cancellationToken);
    
    /// <summary>
    /// Поиск Транзакции по хэш-идентификатору
    /// </summary>
    /// <param name="receiverId">Идентификатор получателя</param>
    /// <param name="senderId">Идентификатор отправителя</param>
    /// <param name="createdAt">Время создания транзакции</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Объект <see cref="Domain.Transaction.Transaction"/></returns>
    Task<TransactionDto> GetByHasKeyAsync(Guid receiverId, Guid senderId, DateTime createdAt,
        CancellationToken cancellationToken);

    /// <summary>
    /// Создание транзакции
    /// </summary>
    /// <param name="transaction">Модель создание Транзакции</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateAsync(CreateTransactionDto transaction, CancellationToken cancellationToken);

}