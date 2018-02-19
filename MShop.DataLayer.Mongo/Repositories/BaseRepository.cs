using MongoDB.Bson;
using MongoDB.Driver;

namespace MShop.DataLayer.Mongo.Repositories
{
	public class BaseRepository
	{
		protected readonly IMongoDatabase _database;

		protected IMongoCollection<BsonDocument> GetBsonCollection<T>() where T : class
		{
			return this._database.GetCollection<BsonDocument>(typeof(T).Name.ToLower());
		}
		protected IMongoCollection<T> GetCollection<T>(string name) 
		{
			return _database.GetCollection<T>(name.ToLower());
		}
		public BaseRepository(IMongoClient client, string databaseName)
		{
			this._database = client.GetDatabase(databaseName);
		}
	}
}
