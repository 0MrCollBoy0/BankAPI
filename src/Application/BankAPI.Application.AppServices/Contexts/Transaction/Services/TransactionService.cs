using AutoMapper;
using BankAPI.Application.AppServices.Contexts.Transaction.Repositories;
using BankAPI.Contracts.Contexts.Transaction;

namespace BankAPI.Application.AppServices.Contexts.Transaction.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repository;
    private readonly IMapper _mapper;

    public TransactionService(ITransactionRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<List<TransactionDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _repository.GetAllAsync(cancellationToken);
    }

    public Task<TransactionDto> GetByHasKeyAsync(Guid receiverId, Guid senderId, DateTime createdAt, CancellationToken cancellationToken)
    {
        return _repository.GetByHasKeyAsync(receiverId, senderId, createdAt, cancellationToken);
    }
}