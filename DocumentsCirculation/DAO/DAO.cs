using System.Data.SqlClient;
using log4net;
using log4net.Config;

namespace DocumentsCirculation.DAO
{
    public class DAO
    {
        private const string ConnectionString = @"Initial Catalog = DocCirculation;" + @"Data Source=.\SQLEXPRESS;" + @"Integrated Security=True;" + @"Pooling=False";

        public SqlConnection Connection { get; set; }

        public void Connect()
        {
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }

        public void Disconnect()
        {
            Connection.Close();
        }
    }
}