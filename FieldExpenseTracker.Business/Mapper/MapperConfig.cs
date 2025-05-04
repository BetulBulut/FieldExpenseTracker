using AutoMapper;
using FieldExpenseTracker.Core.Enums;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Schema;

namespace FieldExpenseTracker.Business.Mapper;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
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

        CreateMap<Expense, ExpenseResponse>();
        CreateMap<ExpenseRequest, Expense>()
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => Enum.Parse<CurrencyEnum>(src.Currency)));

        CreateMap<ExpenseCategory, ExpenseCategoryResponse>();
        CreateMap<ExpenseCategoryRequest, ExpenseCategory>();

        CreateMap<User, UserResponse>();
        CreateMap<User, UserRegisterResponse>();
        CreateMap<UserRequest, User>();
    }
}