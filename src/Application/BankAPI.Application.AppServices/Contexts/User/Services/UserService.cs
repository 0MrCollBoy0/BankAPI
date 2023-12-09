using AutoMapper;
using BankAPI.Application.AppServices.Contexts.User.Repositories;
using BankAPI.Contracts.Contexts.User;
using BankAPI.Domain.User;

namespace BankAPI.Application.AppServices.Contexts.User.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync(cancellationToken);
    }

    public async Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(id, cancellationToken);
    }

    public Task CreateAsync(CreateUserDto user, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Domain.User.User>(user);
        return _repository.CreateAsync(entity, cancellationToken);
    }

    public Task UpdateAsync(UpdateUserDto user, CancellationToken cancellationToken)
    {
        return _repository.UpdateAsync(user, cancellationToken);
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.DeleteAsync(id, cancellationToken);
    }
}