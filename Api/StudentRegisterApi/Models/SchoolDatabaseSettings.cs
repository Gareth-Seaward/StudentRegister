using StudentRegisterApi.Models.Interfaces;
using System;

namespace StudentRegisterApi.Models
{
    public class SchoolDatabaseSettings : ISchoolsDatabaseSettings
    {
        private const string Mongo_Root_User = "MONGO_USERNAME";
        private const string Mongo_Root_Password = "MONGO_PASSWORD";
        private const string Mongo_Host = "MONGO_HOST";

        public string StudentsCollectionName { get; set; }
        public string CoursesCollectionName { get; set; }

        private string _host;
        public string Host 
        { 
            get 
            { 
                if(string.IsNullOrEmpty(GetHostName())) 
                    return _host;
                return GetHostName();
            } 
            set { _host = value; } 
        }
        public string Port { get; set; }
        public string DatabaseName { get; set; }
        public string UserName { get { return GetUserName(); } }
        public string Password { get { return GetPassword(); } }

        public string GetUserName()
        {
            return Environment.GetEnvironmentVariable(Mongo_Root_User);
        }

        public string GetPassword()
        {
            return Environment.GetEnvironmentVariable(Mongo_Root_Password);
        }

        public string GetHostName()
        {
            return Environment.GetEnvironmentVariable(Mongo_Host);
        }
    }
}
