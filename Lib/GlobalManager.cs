using System;
using Lib.Managers;

namespace Lib
{
	public class GlobalManager
    {
		private string connector;
		private string database;

		public UserManager User;
		public PostManager Post;
		public ImageManager Image;

        public GlobalManager(string connector , string database)
		{
			this.connector = connector;
			this.database = database;

			User = new UserManager(connector, database , "users");
			Post = new PostManager(connector, database , "posts");
            Image = new ImageManager(connector, database , "images");
        }

	}
}

