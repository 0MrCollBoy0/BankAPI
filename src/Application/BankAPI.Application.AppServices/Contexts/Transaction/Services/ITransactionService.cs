using BankAPI.Contracts.Contexts.Transaction;

namespace BankAPI.Application.AppServices.Contexts.Transaction.Services;

public interface ITransactionService
{
    /// <summary>
    /// Поиск всех Транзакций
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список Транзакций</returns>
    Task<List<TransactionDto>> GetAllAsync(CancellationToken cancellationToken);
    
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
    
}