namespace UnikOnBoarding.Infrastructure.Contract.Dto
{
    public class TaskEditRequestDto
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public int ProjectId { get; set; }
        public int RoleId { get; set; }
        public string UserId { get; set; } // Email
        public byte[] RowVersion { get; set; }
    }
}
