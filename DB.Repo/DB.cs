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
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionAlfa"].ConnectionString);
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
