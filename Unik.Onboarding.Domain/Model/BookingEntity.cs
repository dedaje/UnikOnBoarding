namespace Unik.Onboarding.Domain.Model;

public class BookingEntity
{
    // For Entity Framework only!!!
    internal BookingEntity()
    {
    }

    public BookingEntity(DateTime date, bool isBooked, string? userId)
    {
        Date = date;
        IsBooked = isBooked;
        UserId = userId;
    }

    public int Id { get; private set; }
    public DateTime Date { get; private set; }
    public bool IsBooked { get; private set; }
    public string? UserId { get; private set; }
    public byte[] RowVersion { get; private set; }

    public void Edit(bool isBooked, string userId, byte[] rowVersion)
    {
        IsBooked = isBooked;
        UserId = userId;
        RowVersion = rowVersion;
    }
}