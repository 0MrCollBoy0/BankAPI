using BankAPI.Application.AppServices.Contexts.Bill.Services;
using BankAPI.Contracts.Contexts.Bill;
using BankAPI.Contracts.Contexts.Transaction;
using Microsoft.AspNetCore.Mvc;

namespace BankAPI.Hosts.Api.Controllers;

/// <summary>
/// Управление моделью <see cref="Domain.Bill.Bill"/>
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class BillController : ControllerBase
{
    private readonly IBillService _billService;

    public BillController(IBillService billService)
    {
        _billService = billService;
    }

    /// <summary>
    /// Получение всех объектов Счетов
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список Счетов</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        return Ok(await _billService.GetAllAsync(cancellationToken));
    }
    
    /// <summary>
    /// Получение объекта Счет по заданному ключу
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Объект <see cref="BillDto"/></returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await _billService.GetByIdAsync(id, cancellationToken));
    }

    /// <summary>
    /// Создание объекта Счет
    /// </summary>
    /// <param name="bill"><see cref="CreateBillDto"/></param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateBillDto bill, CancellationToken cancellationToken)
    {
        await _billService.CreateAsync(bill, cancellationToken);
        return Created(nameof(CreateAsync), null);
    }

    /// <summary>
    /// Удаление объекта Счет
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        await _billService.DeleteAsync(id, cancellationToken);
        return Ok();
    }

    /// <summary>
    /// Создание Транзакции
    /// </summary>
    /// <param name="transaction">Модель создания транзакции</param>
    /// <param name="idSender">Идентификатор отправителя</param>
    /// <param name="idReceiver">Идентификатор получателя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost("{idReceiver:guid}")]
    public async Task<IActionResult> CreateTransactionAsync(CreateTransactionDto transaction, Guid idSender,
        Guid idReceiver, CancellationToken cancellationToken)
    {
        await _billService.CreateTransactionAsync(transaction, idSender, idReceiver, cancellationToken);
        return Created(nameof(CreateTransactionAsync), null);
    }
}