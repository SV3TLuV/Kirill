namespace Api.Models.Teachers.Queries;

public sealed record GetTeacherGroupsQuery(int? CourseId, int? SemesterId);