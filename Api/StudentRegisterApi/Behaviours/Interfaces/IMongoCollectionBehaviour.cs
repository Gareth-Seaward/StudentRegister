using MongoDB.Driver;

namespace StudentRegisterApi.Behaviours.Interfaces
{
    public interface IMongoCollectionBehaviour<T>
    {
        IMongoCollection<T> GetCollection(string collectionName);
    }
}
