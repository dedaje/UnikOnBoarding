namespace UnikOnBoarding.Infrastructure.Contract.Dto.UserProjects
{
    public class UserProjectsQueryResultDto
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime DateCreated { get; set; }
        public byte[] RowVersion { get; set; }

        public string UserId { get; set; }
    }
}
