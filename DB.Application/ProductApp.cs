using System;
using DB.Repo;
using DB.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtivSem03;
using System.Data.SqlClient;

namespace DB.Application
{
    public class ProductApp
    {
        private db db;
        private void Insert(Product product)
        {
            var strQuery = "";
            strQuery += "INSERT INTO [Product](Name, Description, Ingredients)";
            strQuery += String.Format(" VALUES ('{0}','{1}','{2}')", product.Name, product.Description, product.Ingredients);

            using (db = new db())
            {
                db.RunCmd(strQuery);
            }
        }
        private void Update(Product product)
        {
            var strQuery = "";
            strQuery += "UPDATE [Product] SET ";
            strQuery += String.Format("Name = '{0}',", product.Name);
            strQuery += String.Format("Description = '{0}',", product.Description);
            strQuery += String.Format("Ingredients = '{0}'", product.Ingredients);


            using (db = new db())
            {
                db.RunCmd(strQuery);
            }
        }
        public void Save(Product product)
        {
            if (product.Id > 0)
            {
                Update(product);
            }
            else
            {
                Insert(product);
            }
        }
        public void Delete(int id)
        {
            using (db = new db())
            {
                var strQuery = String.Format("DELETE FROM [Product] WHERE Id = {0}", id);
                db.RunCmd(strQuery);
            }
        }
        public List<Product> ListAll()
        {
            using (db = new db())
            {
                var strQuery = "SELECT * FROM [Product]";
                var returnStrQuery = db.CmdReturn(strQuery);
                return ReaderList(returnStrQuery);
            }
        }

        public Product ListId(int id)
        {
            using (db = new db())
            {
                var strQuery = string.Format("SELECT * FROM [Product] WHERE Id = {0}", id);
                var returnStrQuery = db.CmdReturn(strQuery);
                return ReaderList(returnStrQuery).FirstOrDefault();
            }
        }


        public List<Product> ReaderList(SqlDataReader reader)
        {
            var product = new List<Product>();
            while (reader.Read())
            {
                var objectTime = new Product()
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    Ingredients = reader["Ingredients"].ToString(),
                };
                product.Add(objectTime);
            }
            reader.Close();
            return product;
        }
    }
}
