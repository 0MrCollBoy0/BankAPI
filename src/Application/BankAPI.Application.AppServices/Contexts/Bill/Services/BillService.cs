using System.Security.Claims;
using AutoMapper;
using BankAPI.Application.AppServices.Contexts.Bill.Repositories;
using BankAPI.Application.AppServices.Contexts.User.Repositories;
using BankAPI.Contracts.Contexts.Bill;

namespace BankAPI.Application.AppServices.Contexts.Bill.Services;
/// <inheritdoc/>
public class BillService : IBillService
{
    private static readonly Guid MockUserId = Guid.Parse("");
    
    private readonly IBillRepository _repository;
    private readonly IMapper _mapper;
    
    public BillService(IBillRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public async Task<List<BillDto>> GetAllByUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(x => x.UserId == userId, cancellationToken);
    }

    /// <inheritdoc/>
    public Task<BillDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.GetDtoByIdAsync(id, cancellationToken);
    }

    /// <inheritdoc/>
    public Task CreateAsync(CreateBillDto bill, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Domain.Bill.Bill>(bill);
        return _repository.CreateAsync(entity, cancellationToken);
    }

    /// <inheritdoc/>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.DeleteAsync(id, cancellationToken);
    }
    
}