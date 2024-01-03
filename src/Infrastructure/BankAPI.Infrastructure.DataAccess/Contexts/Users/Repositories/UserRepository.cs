using AutoMapper;
using AutoMapper.QueryableExtensions;
using BankAPI.Application.AppServices.Contexts.User.Repositories;
using BankAPI.Contracts.Contexts.User;
using BankAPI.Domain.User;
using BankAPI.Infrastructure.DataAccess.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BankAPI.Infrastructure.DataAccess.Contexts.Users.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IRepository<User> _repository;
    private readonly IMapper _mapper;

    public UserRepository(IRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public Task<List<UserDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _repository.Query()
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);
    }

    public Task<UserDto> GetDtoByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.Query()
            .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }
    public Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _repository.Query()
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public async Task CreateAsync(User user, CancellationToken cancellationToken)
    {
        await _repository.AddAsync(user, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(UpdateUserDto user, CancellationToken cancellationToken)
    {
        var result = await  _repository.Query()
            .FirstOrDefaultAsync(u => u.Id == user.Id, cancellationToken);
        _mapper.Map(user, result);
        await _repository.UpdateAsync(result, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await _repository.Query()
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
        await _repository.DeleteAsync(user, cancellationToken);
        await _repository.SaveChangesAsync(cancellationToken);
    }
}