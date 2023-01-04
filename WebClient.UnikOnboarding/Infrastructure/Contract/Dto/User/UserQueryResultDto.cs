namespace WebClient.UnikOnBoarding.Infrastructure.Contract.Dto.User
{
    public class UserQueryResultDto
    {
        public int Id { get; set; } // PK
        public string UserId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
