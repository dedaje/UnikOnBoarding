﻿namespace UnikOnBoarding.Pages.Project;

public class ProjectEditViewModel
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] RowVersion { get; set; }
}