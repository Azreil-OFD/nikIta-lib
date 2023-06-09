using System.Text.Json;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Lib.DB
{
    public class MongoDBManager
    {
        public IMongoDatabase database;
        public IMongoCollection<BsonDocument> collection;

        public MongoDBManager(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseName);
            collection = database.GetCollection<BsonDocument>(collectionName);
        }


        public void InsertDocument(BsonDocument document)
        {
            collection.InsertOne(document);
        }

        public BsonDocument GetDocumentById(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            return collection.Find(filter).FirstOrDefault();
        }

        public BsonDocument GetDocumentByField(string fieldName, string fieldValue)
        {
            var filter = Builders<BsonDocument>.Filter.Eq(fieldName, fieldValue);
            return collection.Find(filter).FirstOrDefault();
        }

        public List<BsonDocument> GetDocuments()
        {
            var filter = Builders<BsonDocument>.Filter.Empty;
            return collection.Find(filter).ToList();
        }

        public void UpdateDocument(string id, BsonDocument document)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            collection.ReplaceOne(filter, document);
        }

        public void DeleteDocument(string id)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", ObjectId.Parse(id));
            collection.DeleteOne(filter);
        }
    }

}