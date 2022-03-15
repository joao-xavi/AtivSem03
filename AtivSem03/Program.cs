using System.Data.SqlClient;
using DB.Repo;
using DB.Domain;
using DB.Application;

namespace DOS
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new db();
            

            SqlConnection connection = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=AtivSem03;Data Source=DESKTOP-EJA8B8K\SQLEXPRESS");
            connection.Open();

            string strQueryUpdate = "UPDATE [User] SET Name = 'João Paulo' WHERE Id = 2";


            //string strQueryDelete = "DELETE FROM [User] WHERE Id = 2";
            
            string Name = "Marcos Galli";
            string Email = "marcosgalli@gmail.com";
            int ProductId = 2;
            var users = new User()
            {
                Name = Name,
                Email = Email,
                Product = ProductId
            };
            
            //new UserApp().Save(users);
            
            //new UserApp().Delete(11);
            
            var reader = new UserApp().ListAll();
            
            foreach(var user in reader)
            {
                Console.WriteLine("Id: {0}, Name: {1}, Email: {2}, Date: {3}, Product: {4}", user.Id, user.Name, user.Email, user.CreatedDate,user.Product);
            }
        }
    }

}