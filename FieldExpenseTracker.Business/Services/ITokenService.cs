using FieldExpenseTracker.Core.Models;

namespace FieldExpenseTracker.Business.Services;

public interface ITokenService
{
    public string GenerateToken(User user);
}