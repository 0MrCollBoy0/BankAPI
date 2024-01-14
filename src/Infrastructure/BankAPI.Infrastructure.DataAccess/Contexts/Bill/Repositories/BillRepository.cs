using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankAPI.Application.AppServices.Contexts.Bill.Repositories;
using BankAPI.Contracts.Contexts.Bill;
using BankAPI.Infrastructure.DataAccess.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Infrastructure.DataAccess.Contexts.Bill.Repositories;

/// <inheritdoc/>
public class BillRepository : IBillRepository
{
    private readonly IRepository<Domain.Bill.Bill> _repository;
    private readonly IRepository<Domain.Transaction.Transaction> _repositoryTransaction;
    private readonly IMapper _mapper;

    public BillRepository(IRepository<Domain.Bill.Bill> repository, IMapper mapper, IRepository<Domain.Transaction.Transaction> repositoryTransaction)
    {
        _repository = repository;
        _repositoryTransaction = repositoryTransaction;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public Task<List<BillDto>> GetAllAsync(Expression<Func<Domain.Bill.Bill, bool>> filter,
        CancellationToken cancellationToken)
    {
        return _repository.Query()
            .Where(filter)
            .ProjectTo<BillDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public Task<BillDto> GetDtoByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.Query()
            .ProjectTo<BillDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<Domain.Bill.Bill> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.Query().FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task CreateAsync(Domain.Bill.Bill bill, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(bill, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var bill = await _repository.Query()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
        await _repository.DeleteAsync(bill, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }
    
}