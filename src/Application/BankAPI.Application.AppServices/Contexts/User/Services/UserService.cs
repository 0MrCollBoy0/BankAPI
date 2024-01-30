using AutoMapper;
using BankAPI.Application.AppServices.Contexts.User.Repositories;
using BankAPI.Contracts.Contexts.User;
using BankAPI.Domain.User;

namespace BankAPI.Application.AppServices.Contexts.User.Services;

/// <inheritdoc/>
public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc/>
    public Task<List<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return  _repository.GetAllAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return  _repository.GetDtoByIdAsync(id, cancellationToken);
    }

    /// <inheritdoc/>
    public Task CreateAsync(CreateUserDto user, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Domain.User.User>(user);
        return _repository.CreateAsync(entity, cancellationToken);
    }

    /// <inheritdoc/>
    public Task UpdateAsync(UpdateUserDto user, CancellationToken cancellationToken)
    {
        return _repository.UpdateAsync(user, cancellationToken);
    }

    /// <inheritdoc/>
    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.DeleteAsync(id, cancellationToken);
    }
}