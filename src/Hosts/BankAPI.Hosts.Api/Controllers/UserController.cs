using BankAPI.Application.AppServices.Contexts.User.Services;
using BankAPI.Contracts.Contexts.User;
using BankAPI.Domain.User;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Hosts.Api.Controllers;

/// <summary>
/// Управление <see cref="User"/>
/// </summary>
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Получение всех списков Пользователей
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список всех пользователей</returns>
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        return Ok(await _userService.GetAllAsync(cancellationToken));
    }

    /// <summary>
    /// Получение объекта Пользователь по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Возвращает объект Пользователь</returns>
    public async Task<IActionResult> GetByIdAsync (Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _userService.GetByIdAsync(id, cancellationToken));
    }

    /// <summary>
    /// Создание объекта пользователь
    /// </summary>
    /// <param name="user">Модель для создания пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    public async Task<IActionResult> CreateAsync(CreateUserDto user, CancellationToken cancellationToken)
    {
        await _userService.CreateAsync(user, cancellationToken);
        return Created(nameof(CreateAsync), null);
    }

    /// <summary>
    /// Редактирование объекта Пользователь
    /// </summary>
    /// <param name="user">Модель для обновления пользователя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    public async Task<IActionResult> UpdateAsync(UpdateUserDto user, CancellationToken cancellationToken)
    {
        await _userService.UpdateAsync(user, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Удаление объекта пользователь
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _userService.DeleteAsync(id, cancellationToken);
        return Ok();
    }
}