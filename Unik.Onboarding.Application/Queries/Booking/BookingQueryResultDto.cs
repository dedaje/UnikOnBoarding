namespace Unik.Onboarding.Application.Queries.Booking;

public class BookingQueryResultDto
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string? UserId { get; set; }
    public byte[] RowVersion { get; set; }
}