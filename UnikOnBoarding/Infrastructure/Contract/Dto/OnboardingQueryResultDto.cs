﻿namespace UnikOnBoarding.Infrastructure.Contract.Dto
{
    public class OnboardingQueryResultDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime Date { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
