using AutoMapper;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Schema;

namespace FieldExpenseTracker.Business.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        // Employee Mappings
        CreateMap<Employee, EmployeeResponse>();
        CreateMap<EmployeeRequest, Employee>();

        // EmployeeAddress Mappings
        CreateMap<EmployeeAddress, EmployeeAddressResponse>()
            .ForMember(dest => dest.FullAddress, opt => opt.MapFrom(src => $"{src.Street}, {src.City}, {src.State}, {src.ZipCode}, {src.Country}"));
        CreateMap<EmployeeAddressRequest, EmployeeAddress>();

        // EmployeePhone Mappings
        CreateMap<EmployeePhone, EmployeePhoneResponse>();
        CreateMap<EmployeePhoneRequest, EmployeePhone>();

        // EmployeeIBAN Mappings
        CreateMap<EmployeeIBAN, EmployeeIBANResponse>();
        CreateMap<EmployeeIBANRequest, EmployeeIBAN>();

        // Expense Mappings
        CreateMap<Expense, ExpenseResponse>();
        CreateMap<ExpenseRequest, Expense>();

        // ExpenseCategory Mappings
        CreateMap<ExpenseCategory, ExpenseCategoryResponse>();
        CreateMap<ExpenseCategoryRequest, ExpenseCategory>();

        // User Mappings
        CreateMap<User, UserResponse>();
        CreateMap<UserRequest, User>();
    }
}