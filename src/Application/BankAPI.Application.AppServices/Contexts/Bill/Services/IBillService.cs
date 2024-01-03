﻿using BankAPI.Contracts.Contexts.Bill;
using BankAPI.Contracts.Contexts.Transaction;

namespace BankAPI.Application.AppServices.Contexts.Bill.Services;

/// <summary>
/// Сервис для работы с <see cref="Domain.Bill.Bill"/>
/// </summary>
public interface IBillService
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
    Task<BillDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Создание <see cref="Domain.Bill.Bill"/>
    /// </summary>
    /// <param name="bill"><see cref="CreateBillDto"/></param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateAsync(CreateBillDto bill, CancellationToken cancellationToken);
    
    /// <summary>
    /// Удаление <see cref="Domain.Bill.Bill"/>
    /// </summary>
    /// <param name="id">Идентификатор</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Создание <see cref="Domain.Transaction.Transaction"/>
    /// </summary>
    /// <param name="transaction">Модель создания Транзакции</param>
    /// <param name="idSender">Идентификатор отправителя</param>
    /// <param name="idReceiver">Идентификатор получателя</param>
    /// <param name="cancellationToken">Токен отмены</param>
    Task CreateTransactionAsync(CreateTransactionDto transaction, Guid idSender, Guid idReceiver,
        CancellationToken cancellationToken);
}