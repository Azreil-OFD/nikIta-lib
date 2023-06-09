using System;
using Lib.DB;
using Lib.Models;
using MongoDB.Bson;

namespace Lib.Managers
{
    public class PostManager
    {
        private MongoDBManager mongoDBManager;

        public PostManager(string connector, string database, string collection)
        {
            mongoDBManager = new MongoDBManager(connector, database, collection);
        }

        public PostManager(string connector, string database)
        {
            mongoDBManager = new MongoDBManager(connector, database, "User");
        }

        public bool CreatePost(Post post)
        {
            var data = mongoDBManager.GetDocumentByField("title", post.Title);

            if (data == null)
            {
                var document = new BsonDocument
                {
                    { "title", post.Title },
                    { "description", post.Description },
                    { "type", post.Type },
                    { "city", post.City },
                    { "address", post.Address },
                    { "create_at", post.CreatedAt },
                    { "owner_id", post.OwnerId },
                    { "visible", post.Visible },
                    { "solar", post.Solar },
                    { "images", new BsonArray(post.Images) },
                    { "tags", new BsonArray(post.Tags) },
                    { "like", new BsonArray(post.Like) }
                };

                mongoDBManager.InsertDocument(document);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePost(string postId, Post post)
        {
            var data = mongoDBManager.GetDocumentById(postId);

            if (data != null)
            {
                var document = new BsonDocument
                {
                    { "title", post.Title },
                    { "description", post.Description },
                    { "type", post.Type },
                    { "city", post.City },
                    { "address", post.Address },
                    { "create_at", post.CreatedAt },
                    { "owner_id", post.OwnerId },
                    { "visible", post.Visible },
                    { "solar", post.Solar },
                    { "images", new BsonArray(post.Images) },
                    { "tags", new BsonArray(post.Tags) },
                    { "like", new BsonArray(post.Like) }
                };

                mongoDBManager.UpdateDocument(postId, document);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeletePost(string postId)
        {
            var data = mongoDBManager.GetDocumentById(postId);

            if (data != null)
            {
                mongoDBManager.DeleteDocument(postId);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Post> GetAll()
        {
            List<Post> posts = new List<Post>();
            var datas = mongoDBManager.GetDocuments();
            foreach (var data in datas)
            {
                var post = new Post
                {
                    Title = data.GetValue("title").AsString,
                    Description = data.GetValue("description").AsString,
                    Type = data.GetValue("type").AsString,
                    City = data.GetValue("city").AsString,
                    Address = data.GetValue("address").AsString,
                    CreatedAt = data.GetValue("create_at").AsString,
                    OwnerId = data.GetValue("owner_id").AsString,
                    Visible = data.GetValue("visible").AsBoolean,
                    Solar = data.GetValue("solar").AsInt32,
                    Images = data.GetValue("images").AsBsonArray.Select(x => x.ToString()).ToList(),
                    Tags = data.GetValue("tags").AsBsonArray.Select(x => x.ToString()).ToList(),
                    Like = data.GetValue("like").AsBsonArray.Select(x => x.ToString()).ToList()
                };
                posts.Add(post);
            }

            return posts;
        }

        public Post GetPostById(string postId)
        {
            var data = mongoDBManager.GetDocumentById(postId);

            if (data != null)
            {
                var post = new Post
                {
                    Title = data.GetValue("title").AsString,
                    Description = data.GetValue("description").AsString,
                    Type = data.GetValue("type").AsString,
                    City = data.GetValue("city").AsString,
                    Address = data.GetValue("address").AsString,
                    CreatedAt = data.GetValue("create_at").AsString,
                    OwnerId = data.GetValue("owner_id").AsString,
                    Visible = data.GetValue("visible").AsBoolean,
                    Solar = data.GetValue("solar").AsInt32,
                    Images = data.GetValue("images").AsBsonArray.Select(x => x.ToString()).ToList(),
                    Tags = data.GetValue("tags").AsBsonArray.Select(x => x.ToString()).ToList(),
                    Like = data.GetValue("like").AsBsonArray.Select(x => x.ToString()).ToList()
                };

                return post;
            }
            else
            {
                return null;
            }
        }
    }
}
