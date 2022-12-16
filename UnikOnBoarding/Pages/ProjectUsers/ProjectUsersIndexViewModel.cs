﻿namespace UnikOnBoarding.Pages.ProjectUsers;

public class ProjectUsersIndexViewModel
{
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public DateTime DateCreated { get; set; }
    public byte[] RowVersion { get; set; }

    public string UserId { get; set; }
}