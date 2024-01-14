using System.Security.Claims;
using BankAPI.Application.AppServices.Contexts.Bill.Services;
using BankAPI.Contracts.Contexts.Bill;
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
    private readonly IBillService _service;

    public BillController(IBillService service)
    {
        _service = service;
    }

    /// <summary>
    /// Получение всех объектов Счетов
    /// </summary>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>Список Счетов</returns>
    [HttpGet]
    public async Task<IActionResult> GetAllByUserAsync(CancellationToken cancellationToken)
    {
        var userGuid = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value);
        return Ok(await _service.GetAllByUserAsync(userGuid, cancellationToken));
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
        return Ok(await _service.GetByIdAsync(id, cancellationToken));
    }

    /// <summary>
    /// Создание объекта Счет
    /// </summary>
    /// <param name="bill"><see cref="CreateBillDto"/></param>
    /// <param name="cancellationToken">Токен отмены</param>
    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateBillDto bill, CancellationToken cancellationToken)
    {
        await _service.CreateAsync(bill, cancellationToken);
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
        await _service.DeleteAsync(id, cancellationToken);
        return Ok();
    }
}