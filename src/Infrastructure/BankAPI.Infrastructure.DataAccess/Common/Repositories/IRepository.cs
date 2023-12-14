namespace BankAPI.Infrastructure.DataAccess.Common.Repositories;

/// <summary>
/// Базовый репозиторий
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
public interface IRepository<T> where T : class
{
    /// <summary>
    /// Получает не материализованный запрос
    /// </summary>
    /// <returns>Не материализованный запрос</returns>
    public IQueryable<T> Query();

    /// <summary>
    /// Добавляет сущность в БД
    /// </summary>
    /// <param name="entity">Сущность</param>
    /// <param name="cancellationToken">Токен отмены</param>
    public Task AddAsync(T entity, CancellationToken cancellationToken);
    
    /// <summary>
    /// Обновляет сущность в БД
    /// </summary>
    /// <param name="entity">Сущность</param>
    /// <param name="cancellationToken">Токен отмены</param>
    public Task UpdateAsync(T entity, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаляет сущность из БД
    /// </summary>
    /// <param name="entity">Сущность</param>
    /// <param name="cancellationToken">Токен отмены</param>
    public Task DeleteAsync(T entity, CancellationToken cancellationToken);
    
    /// <summary>
    /// Применяет изменения в БД
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    public Task SaveChangesAsync(CancellationToken cancellationToken);
}