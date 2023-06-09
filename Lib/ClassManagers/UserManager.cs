using Lib.DB;
using Lib.Models;
using MongoDB.Bson;

namespace Lib.Managers
{
    public class UserManager
    {
        private MongoDBManager mongoDBManager;

        public UserManager(string connector, string database, string collection)
        {
            mongoDBManager = new MongoDBManager(connector, database, collection);
        }

        public UserManager(string connector, string database)
        {
            mongoDBManager = new MongoDBManager(connector, database, "User");
        }

        public bool Register(string login, string password)
        {
            var data = mongoDBManager.GetDocumentByField("Login", login);

            if (data == null)
            {
                var user = new User
                {
                    Login = login,
                    Password = password
                };

                mongoDBManager.InsertDocument(user.ToBsonDocument());
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Login(string login, string password)
        {
            var data = mongoDBManager.GetDocumentByField("Login", login);

            if (data != null)
            {
                if (data["Password"] == password)
                    return true;
                return false;
            }
            else
            {
                return false;
            }
        }

        public User GetUser(string login, string password)
        {
            var data = mongoDBManager.GetDocumentByField("Login", login);

            if (data != null)
            {
                if (data["Password"] == password)
                {
                    var user = new User
                    {
                        Id = data["_id"].ToString(),
                        Login = data["Login"].ToString(),
                        Password = data["Password"].ToString()
                    };

                    return user;
                }

                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
