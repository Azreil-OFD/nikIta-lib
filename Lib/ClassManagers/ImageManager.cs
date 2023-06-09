using System.IO;
using MongoDB.Bson;
using MongoDB.Driver;
using Lib.DB;

namespace Lib.Managers
{
    public class ImageManager
    {
        private MongoDBManager dbManager;

        public ImageManager(string connectionString, string databaseName, string collectionName)
        {
            dbManager = new MongoDBManager(connectionString, databaseName, collectionName);
        }

        public ImageManager(string connectionString, string databaseName)
        {
            dbManager = new MongoDBManager(connectionString, databaseName, "images");
        }

        public string AddImage(string imagePath)
        {
            ObjectId imageId = ObjectId.GenerateNewId();
            BsonDocument imageDocument = new BsonDocument
            {
                { "_id", imageId },
                { "image", GetImageBytes(imagePath) }
            };
            dbManager.InsertDocument(imageDocument);
            return imageId.ToString();
        }

        public MemoryStream GetImageById(string id)
        {
            BsonDocument imageDocument = dbManager.GetDocumentById(id);
            if (imageDocument != null && imageDocument.Contains("image"))
            {
                byte[] imageBytes = imageDocument["image"].AsByteArray;
                return new MemoryStream(imageBytes);
            }
            return null;
        }

        private byte[] GetImageBytes(string imagePath)
        {
            return File.ReadAllBytes(imagePath);
        }
    }
}
