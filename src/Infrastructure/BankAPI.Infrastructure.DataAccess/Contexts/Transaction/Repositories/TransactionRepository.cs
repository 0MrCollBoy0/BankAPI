using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankAPI.Application.AppServices.Contexts.Transaction;
using BankAPI.Application.AppServices.Contexts.Transaction.Repositories;
using BankAPI.Contracts.Contexts.Transaction;
using BankAPI.Infrastructure.DataAccess.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Infrastructure.DataAccess.Contexts.Transaction.Repositories;

public class TransactionRepository : ITransactionRepository
{
    private readonly IRepository<Domain.Transaction.Transaction> _repository;
    private readonly IMapper _mapper;

    public TransactionRepository(IRepository<Domain.Transaction.Transaction> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Task<List<TransactionDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _repository.Query()
            .ProjectTo<TransactionDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public Task<TransactionDto> GetByHasKeyAsync(Guid receiverId, Guid senderId, DateTime createdAt,
        CancellationToken cancellationToken)
    {
        return _repository.Query()
            .Where(transaction => transaction.ReceiverId == receiverId
                                  && transaction.SenderId == senderId
                                  && transaction.CreatedAt == createdAt)
            .ProjectTo<TransactionDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken);

    }
}