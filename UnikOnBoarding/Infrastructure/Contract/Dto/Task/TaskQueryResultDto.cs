namespace UnikOnBoarding.Infrastructure.Contract.Dto.Task
{
    public class TaskQueryResultDto
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProjectId { get; set; }
        public int RoleId { get; set; }
        public string UserId { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
