using System.Linq.Expressions;
using BankAPI.Contracts.Contexts.Transaction;

namespace BankAPI.Application.AppServices.Contexts.Transaction.Repositories;

/// <summary>
/// Репозиторий для работы с моделью <see cref="Domain.Transaction.Transaction"/>
/// </summary>
public interface ITransactionRepository
{
    /// <summary>
    /// Поиск всех Транзакций
    /// </summary>
    /// <param name="filter">Условие для фильтрации Транзакций</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список Транзакций</returns>
    Task<List<TransactionDto>> GetAllAsync(Expression<Func<Domain.Transaction.Transaction, bool>> filter,
        CancellationToken cancellationToken);

    /// <summary>
    /// Поиск Транзакции по хэш-идентификатору
    /// </summary>
    /// <param name="receiverId">Идентификатор получателя</param>
    /// <param name="senderId">Идентификатор отправителя</param>
    /// <param name="createdAt">Время создания транзакции</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Объект <see cref="Domain.Transaction.Transaction"/></returns>
    Task<TransactionDto> GetByHashKeyAsync(Guid receiverId, Guid senderId, DateTime createdAt,
        CancellationToken cancellationToken);

    /// <summary>
    /// Создание Транзакции
    /// </summary>
    /// <param name="transaction">Транзакция</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateAsync(Domain.Transaction.Transaction transaction, CancellationToken cancellationToken);
}