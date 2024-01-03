using BankAPI.Application.AppServices.Contexts.Transaction.Services;
using BankAPI.Contracts.Contexts.Transaction;
using BankAPI.Domain.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Hosts.Api.Controllers;
/// <summary>
/// Управление <see cref="Transaction"/>
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
//[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status500InternalServerError)]
public class TransactionController:ControllerBase
{
    private readonly ITransactionService _service;

    public TransactionController(ITransactionService service)
    {
        _service = service;
    }

    /// <summary>
    /// Получение всех объектов <see cref="Transaction"/>
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список всех Транзакций</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        return Ok(await _service.GetAllAsync(cancellationToken));
    }

    /// <summary>
    /// Поиск Транзакции по ключу
    /// </summary>
    /// <param name="receiverId">Идентификатор Получателя</param>
    /// <param name="senderId">Идентификатор отправителя</param>
    /// <param name="createdAt">Время создания Транзакции</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Объект <see cref="Transaction"/></returns>
    [HttpGet("{receiverId:Guid}")]
    public async Task<IActionResult> GetByHasKey(Guid receiverId, Guid senderId, DateTime createdAt,
        CancellationToken cancellationToken)
    {
        return Ok(await _service.GetByHasKeyAsync(receiverId, senderId, createdAt, cancellationToken));
    }
    
}