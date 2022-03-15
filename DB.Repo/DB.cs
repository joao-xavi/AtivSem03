using System;
using System.Data.SqlClient;
using System.Configuration;


namespace DB.Repo
{
    public class db : IDisposable
    {
        private readonly SqlConnection connection;
        public db()
        {
            connection = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=AtivSem03;Data Source=DESKTOP-EJA8B8K\\SQLEXPRESS");
            connection.Open();
        }
        public void RunCmd(string strQuery)
        {
            var cmd = new SqlCommand
            {
                CommandText = strQuery,
                CommandType = System.Data.CommandType.Text,
                Connection = connection
            };
            cmd.ExecuteNonQuery();
        }

        public SqlDataReader CmdReturn(string strQuery)
        {
            var cmdSelect = new SqlCommand(strQuery, connection);
            return cmdSelect.ExecuteReader();
        }

        public void Dispose()
        {
            if (connection != null)
            {
                connection.Close();
            }
        }
    }
}
