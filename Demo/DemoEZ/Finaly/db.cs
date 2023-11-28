using System.Data.SqlClient;

namespace Demo
{
    class db
    {
        
        SqlConnection sqlConnection = new SqlConnection ("Server = MrCat\\SQLEXPRESS; Database = test;Integrated Security = True;");

        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)    
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open) 
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}
