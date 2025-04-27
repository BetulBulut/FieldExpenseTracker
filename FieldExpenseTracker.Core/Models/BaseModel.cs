namespace FieldExpenseTracker.Core.Models;

public class BaseModel
{
    public int Id { get; set; }
    public string InsertedUser { get; set; }
    public string UpdatedUser { get; set; }
    public DateTime InsertedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsActive { get; set; }
}