﻿namespace Unik.Onboarding.Application.Queries.Project;

public class ProjectQueryResultDto
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public DateTime DateAdded { get; set; }
    public string UserId { get; set; }
    public byte[] RowVersion { get; set; }
}