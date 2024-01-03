using BankAPI.Contracts.Contexts.User;


namespace BankAPI.Application.AppServices.Contexts.User.Repositories;

/// <summary>
/// Репозиторий по работе с <see cref="Domain.User.User"/>
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Получение всех <see cref="Domain.User.User"/>
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список моделей <see cref="Domain.User.User"/></returns>
    Task<List<UserDto>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получение <see cref="Domain.User.User"/> по идентификатор
    /// </summary>
    /// <returns>Модель <see cref="Domain.User.User"/></returns>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task<UserDto> GetDtoByIdAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Получение <see cref="Domain.User.User"/> по идентификатор
    /// </summary>
    /// <returns>Модель <see cref="Domain.User.User"/></returns>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task<Domain.User.User> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Создание модели <see cref="Domain.User.User"/>
    /// </summary>
    /// <param name="user"><see cref="Domain.User.User"/></param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateAsync(Domain.User.User user, CancellationToken cancellationToken);

    /// <summary>
    /// Обналяет модель <see cref="Domain.User.User"/>
    /// </summary>
    /// <param name="user"><see cref="UpdateUserDto"/></param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task UpdateAsync(UpdateUserDto user, CancellationToken cancellationToken);

    /// <summary>
    /// Удаляет модель <see cref="Domain.User.User"/>
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}