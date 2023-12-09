﻿using AutoMapper;
using BankAPI.Contracts.Contexts.Bill;
using BankAPI.Domain.Bill;

namespace BankAPI.Infrastructure.ComponentRegistrar.Mapper;

public class BillProfile : Profile
{
    public BillProfile()
    {
        CreateMap<Bill, BillDto>();
        CreateMap<CreateBillDto, Bill>();
    }
}