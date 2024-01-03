using AutoMapper;
using BankAPI.Contracts.Contexts.Transaction;
using BankAPI.Domain.Transaction;

namespace BankAPI.Infrastructure.ComponentRegistrar.Mapper;

public class TransactionProfile : Profile
{
    public TransactionProfile()
    {
        CreateMap<Transaction, TransactionDto>();
        CreateMap<CreateTransactionDto, Transaction>();
    }
    
}