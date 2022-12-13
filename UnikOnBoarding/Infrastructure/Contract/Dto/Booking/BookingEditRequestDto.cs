namespace UnikOnBoarding.Infrastructure.Contract.Dto.Booking
{
    public class BookingEditRequestDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? UserId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
