using AutoMapper;
using FieldExpenseTracker.Core.Enums;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Schema;

namespace FieldExpenseTracker.Business.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        // Employee mappings
        CreateMap<Employee, EmployeeResponse>()
            .ForMember(dest => dest.PhoneNumbers, opt => opt.MapFrom(src => src.PhoneNumbers))
            .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
            .ForMember(dest => dest.IBANs, opt => opt.MapFrom(src => src.IBANs));
        CreateMap<EmployeeRequest, Employee>();

        CreateMap<EmployeeAddress, EmployeeAddressResponse>()
            .ForMember(dest => dest.FullAddress, opt => opt.MapFrom(src => $"{src.Street}, {src.City}, {src.State}, {src.ZipCode}, {src.Country}"));
        CreateMap<EmployeeAddressRequest, EmployeeAddress>();

        CreateMap<EmployeePhone, EmployeePhoneResponse>();
        CreateMap<EmployeePhoneRequest, EmployeePhone>();

        CreateMap<EmployeeIBAN, EmployeeIBANResponse>();
        CreateMap<EmployeeIBANRequest, EmployeeIBAN>();

        // Expense mappings
        CreateMap<Expense, ExpenseResponse>()
            .ForMember(dest => dest.CurrencyName, opt => opt.MapFrom(src => src.Currency.ToString()))
            .ForMember(dest => dest.StatusName, opt => opt.MapFrom(src => ((StatusEnum)src.Status).ToString()))
            .ForMember(dest => dest.ExpenseCategoryName, opt => opt.MapFrom(src => src.ExpenseCategory.Name))
            .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.FirstName + " " + src.Employee.LastName));
           
        
        CreateMap<ExpenseRequest, Expense>()
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => Enum.Parse<CurrencyEnum>(src.Currency)));

        CreateMap<ExpenseResponseRequest, Expense>()
            .ForMember(dest => dest.ResponseDescription, opt => opt.MapFrom(src => src.ResponseDescription))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Approve ? (int)StatusEnum.Approved : (int)StatusEnum.Rejected))
            .ForMember(dest => dest.ResponseDate, opt => opt.MapFrom(_ => DateTime.UtcNow));

        CreateMap<CreateMultipleExpenseRequest, List<Expense>>()
            .ConvertUsing((src, dest, context) => src.Expenses.Select(e => context.Mapper.Map<Expense>(e)).ToList());

        CreateMap<List<Expense>, CreateMultipleExpenseResponse>()
            .ForMember(dest => dest.Expenses, opt => opt.MapFrom(src => src));
        
        // ExpenseCategory mappings
        CreateMap<ExpenseCategory, ExpenseCategoryResponse>();
        CreateMap<ExpenseCategoryRequest, ExpenseCategory>();

        CreateMap<PaymentMethod, PaymentMethodResponse>();
        CreateMap<PaymentMethodRequest, PaymentMethod>();

        // User mappings
        CreateMap<User, UserResponse>();
        CreateMap<User, UserRegisterResponse>();
        CreateMap<UserRequest, User>();
    }
}