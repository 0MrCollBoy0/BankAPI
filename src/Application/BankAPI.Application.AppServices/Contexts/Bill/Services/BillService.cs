using AutoMapper;
using BankAPI.Application.AppServices.Contexts.Bill.Repositories;
using BankAPI.Application.AppServices.Contexts.User.Repositories;
using BankAPI.Contracts.Contexts.Bill;
using BankAPI.Contracts.Contexts.Transaction;

namespace BankAPI.Application.AppServices.Contexts.Bill.Services;

public class BillService : IBillService
{
    private readonly IBillRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public BillService(IBillRepository repository, IMapper mapper, IUserRepository userRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<List<BillDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }

    public Task<BillDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.GetDtoByIdAsync(id, cancellationToken);
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

    public async Task CreateTransactionAsync(CreateTransactionDto transaction, Guid idSender, Guid idReceiver,
        CancellationToken cancellationToken)
    {
        var sender = await _userRepository.GetByIdAsync(idSender, cancellationToken);
        var receiver = await _userRepository.GetByIdAsync(idReceiver, cancellationToken);
        var entity = new Domain.Transaction.Transaction()
        {
            SenderId = sender.Id,
            Sender = sender,
            ReceiverId = transaction.ReceiverId,
            Receiver = receiver,
            CreatedAt = DateTime.Now,
            Sum = transaction.Sum
        };
        await _repository.CreateTransactionAsync(entity, cancellationToken);
    }
}