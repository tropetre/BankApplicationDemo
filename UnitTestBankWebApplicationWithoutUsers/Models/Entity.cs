namespace UnitTestBankWebApplicationWithoutUsers.Models
{
    public interface Entity<TId>
    {
        TId Id { get; }
    }
}