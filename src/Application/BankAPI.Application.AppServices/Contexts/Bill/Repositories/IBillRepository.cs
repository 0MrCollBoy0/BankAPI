using BankAPI.Contracts.Contexts.Bill;

namespace BankAPI.Application.AppServices.Contexts.Bill.Repositories;

/// <summary>
/// Репозиторий для работы с моделью <see cref="Domain.Bill.Bill"/>
/// </summary>
public interface IBillRepository
{
    /// <summary>
    /// Поиск всех Счетов
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список всех Транзакций</returns>
    Task<List<BillDto>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Поиск Счетов по заданному ключу
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Объект <see cref="BillDto"/></returns>
    Task<BillDto> GetDtoByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Поиск Счетов по заданному идентификатор
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Объект <see cref="Domain.Bill.Bill"/></returns>
    Task<Domain.Bill.Bill> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Создание <see cref="Domain.Bill.Bill"/>
    /// </summary>
    /// <param name="bill"><see cref="Domain.Bill.Bill"/></param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateAsync(Domain.Bill.Bill bill, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаление <see cref="Domain.Bill.Bill"/>
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    ///  Создание <see cref="Domain.Transaction.Transaction"/>
    /// </summary>
    /// <param name="transaction">Модель Транзакция</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateTransactionAsync(Domain.Transaction.Transaction transaction, CancellationToken cancellationToken);
}