using AutoMapper;
using BankAPI.Application.AppServices.Contexts.Bill.Repositories;
using BankAPI.Contracts.Contexts.Bill;

namespace BankAPI.Application.AppServices.Contexts.Bill.Services;

public class BillService : IBillService
{
    private readonly IBillRepository _repository;
    private readonly IMapper _mapper;

    public BillService(IBillRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<BillDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }

    public Task<BillDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.GetByIdAsync(id, cancellationToken);
    }

    public Task CreateAsync(CreateBillDto bill, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Domain.Bill.Bill>(bill);
        return _repository.CreateAsync(entity, cancellationToken);
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.DeleteAsync(id, cancellationToken);
    }
}