using MongoDB.Driver;
using StudentRegisterApi.Behaviours.Interfaces;
using StudentRegisterApi.Models.Interfaces;

namespace StudentRegisterApi.Behaviours
{
    public class MongoCollectionBehaviour<T> : IMongoCollectionBehaviour<T>
    {
        private readonly ISchoolsDatabaseSettings _settings;

        public MongoCollectionBehaviour(ISchoolsDatabaseSettings settings)
        {
            _settings = settings;
        }
        public IMongoCollection<T> GetCollection(string collectionName)
        {
            var connectionString = GetConnectionString();
            var database = GetDatabase(connectionString);
            return database.GetCollection<T>(_settings.StudentsCollectionName);
        }

        private string GetConnectionString()
        {
            return $@"mongodb://{_settings.UserName}:{_settings.Password}@{_settings.Host}:{_settings.Port}";
        }

        private IMongoDatabase GetDatabase(string connectionString)
        {
            var client = new MongoClient(connectionString);
            return client.GetDatabase(_settings.DatabaseName);
        }
    }
}
