using AutoMapper;
using BankAPI.Application.AppServices.Contexts.Transaction.Repositories;
using BankAPI.Contracts.Contexts.Transaction;

namespace BankAPI.Application.AppServices.Contexts.Transaction.Services;

/// <inheritdoc/>
public class TransactionService : ITransactionService
{
    private static readonly Guid MockBillId = Guid.Parse("");
    
    private readonly ITransactionRepository _repository;
    private readonly IMapper _mapper;

    
    public TransactionService(ITransactionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public Task<List<TransactionDto>> GetAllByBillAsync(Guid senderId, CancellationToken cancellationToken)
    {
        return _repository.GetAllAsync(x => x.SenderId == senderId, cancellationToken);
    }
    
    /// <inheritdoc/>
    public Task<TransactionDto> GetByHasKeyAsync(Guid receiverId, Guid senderId, DateTime createdAt, CancellationToken cancellationToken)
    {
        return _repository.GetByHashKeyAsync(receiverId, senderId, createdAt, cancellationToken);
    }

    /// <inheritdoc/>
    public Task CreateAsync(CreateTransactionDto transaction, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Domain.Transaction.Transaction>(transaction);
        return _repository.CreateAsync(entity, cancellationToken);
    }
}