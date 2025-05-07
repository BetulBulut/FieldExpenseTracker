using System.Data;
using FieldExpenseTracker.Core.Schema;
using Dapper;

namespace FieldExpenseTracker.Data.Reports;

public class ReportRepository : IReportRepository
{
     private readonly IDbConnection _connection;

      public ReportRepository(IDbConnection dbConnection)
      {
          _connection = dbConnection;
      }

      public async Task<IEnumerable<ExpenseSummaryDto>> GetCompanyExpenseSummaryAsync(int fromYear, int toYear)
      {
          var from = new DateTime(fromYear, 1, 1);
          var to = new DateTime(toYear, 12, 31);
      
          using (var connection = _connection){
              var parameters = new {StartDate = from, EndDate = to};

          var result = await _connection.QueryAsync<ExpenseSummaryDto>(
              "sp_GetCompanyExpenseSummary",
              parameters,
              commandType: CommandType.StoredProcedure);

          return result;
          } 
      }
      public async Task<IEnumerable<EmployeeExpenseDto>> GetEmployeeExpensesAsync(int employeeId)
      {
          using (var connection = _connection){
       
          var parameter =new {EmployeeId= employeeId};

          var result = await _connection.QueryAsync<EmployeeExpenseDto>(
              "sp_GetEmployeeExpenses",
              parameter,
              commandType: CommandType.StoredProcedure);

          return result;
          }
      }
      public async Task<IEnumerable<EmployeeExpenseStatDto>> GetEmployeeExpenseStatsAsync(int fromYear, int toYear)
      {
          var from = new DateTime(fromYear, 1, 1);
          var to = new DateTime(toYear, 12, 31);
          using (var connection = _connection){
          
          var parameters = new {StartDate = from, EndDate = to};

          var result = await _connection.QueryAsync<EmployeeExpenseStatDto>(
              "sp_GetEmployeeExpenseStats",
              parameters,
              commandType: CommandType.StoredProcedure);

          return result;
          }

      }
        public async Task<IEnumerable<ApprovalStatDto>> GetApprovalStatsAsync(int fromYear, int toYear)
        {
        var from = new DateTime(fromYear, 1, 1);
        var to = new DateTime(toYear, 12, 31);
        using (var connection = _connection){
        var parameters = new {StartDate = from, EndDate = to};

        var result = await _connection.QueryAsync<ApprovalStatDto>(
            "sp_GetApprovalStats",
            parameters,
            commandType: CommandType.StoredProcedure);

        return result;
        }
        }
}
