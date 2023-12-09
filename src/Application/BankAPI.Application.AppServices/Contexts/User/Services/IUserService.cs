using BankAPI.Contracts.Contexts.User;
using BankAPI.Domain.User;

namespace BankAPI.Application.AppServices.Contexts.User.Services;

/// <summary>
/// Репозиторий для работы с <see cref="Domain.User.User"/>
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Получение всех пользователей
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список всех объектов Пользователь</returns>
    Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Получение пользователя по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Объект Пользователь</returns>
    Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Создание объекта Пользователь
    /// </summary>
    /// <param name="user"><see cref="CreateUserDto"/></param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateAsync(CreateUserDto user, CancellationToken cancellationToken);

    /// <summary>
    /// Обнавление полей пользователя
    /// </summary>
    /// <param name="user"><see cref="UpdateUserDto"/></param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task UpdateAsync(UpdateUserDto user, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление объекта Пользователь
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);
}