namespace StudentRegisterApi.Models.Interfaces
{
    public interface ISchoolsDatabaseSettings
    {
        string StudentsCollectionName { get; set; }
        string CoursesCollectionName { get; set; }
        string Host { get; set; }
        string Port { get; set; }
        string DatabaseName { get; set; }
        string UserName { get; }
        string Password { get; }
    }
}
