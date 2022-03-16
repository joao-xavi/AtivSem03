using DB.Repo;
using System.Data.SqlClient;
using DB.Domain;




namespace DB.Application
{
    public class UserApp
    {
        private db db;
        private void Insert(User user)
        {
            var strQuery = "";
            strQuery += "INSERT INTO [User](Name, Email, CreatedDate, ProductId)";
            strQuery += String.Format(" VALUES ('{0}','{1}','{2}','{3}')", user.Name, user.Email, DateTime.Now.ToString(), user.Product) ;

            using(db = new db()) 
            {
                db.RunCmd(strQuery); 
            }
        }
        private void Update(User user)
        {
            var strQuery = "";
            strQuery += "UPDATE [User] SET ";
            strQuery += String.Format("Name = '{0}',", user.Name);
            strQuery += String.Format("Email = '{0}',", user.Email);
            strQuery += String.Format("ProductId = '{0}'", user.Product);
            strQuery += String.Format("WHERE Id = {0}", user.Id);
            
            using (db = new db())
            {
                db.RunCmd(strQuery);
            }
        }
        public void Save(User user)
        {
            if(user.Id > 0)
            {
                Update(user);
            }
            else
            {
                Insert(user);
            }
        }
        public void Delete(int id)
        {
            using (db = new db())
            {
                var strQuery = String.Format("DELETE FROM [User] WHERE Id = {0}", id);
                db.RunCmd(strQuery);
            }
        }
        public List<User> ListAll()
        {
            using (db = new db())
            {
                var strQuery = "SELECT * FROM [User]";
                var returnStrQuery = db.CmdReturn(strQuery);
                return ReaderList(returnStrQuery);
            }
        }

        public User ListId(int id)
        {
            using (db = new db())
            {
                var strQuery = string.Format("SELECT * FROM [User] WHERE Id = {0}", id);
                var returnStrQuery = db.CmdReturn(strQuery);
                return ReaderList(returnStrQuery).FirstOrDefault();
            }
        }


        public List<User>ReaderList(SqlDataReader reader)
        {
            var user = new List<User>();
            while (reader.Read())
            {
                var objectTime = new User()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString(),
                    CreatedDate = DateTime.Parse(reader["CreatedDate"].ToString()),
                    Product = int.Parse(reader["ProductId"].ToString()),
                };
                user.Add(objectTime);
            }
            reader.Close();
            return user;
        }
    }
}
