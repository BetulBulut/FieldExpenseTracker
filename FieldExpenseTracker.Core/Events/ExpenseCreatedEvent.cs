public class ExpenseCreatedEvent
{
    public int ExpenseId { get; set; }
    public string EmployeeName { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
}
