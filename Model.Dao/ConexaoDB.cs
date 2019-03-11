using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Model.Dao
{
    public class ConexaoDB
    {
        private static ConexaoDB objConexaoDb = null;
        private SqlConnection sqlConnection;

        //Construtor
        private ConexaoDB()
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ConnectionString);
        }

        public static ConexaoDB OpenConn()
        {
            if (objConexaoDb == null)
            {
                objConexaoDb = new ConexaoDB();
            }
            return objConexaoDb;
        }

        public SqlConnection GetConn()
        {
            if (objConexaoDb == null)
            {
                objConexaoDb = new ConexaoDB();
            }

            if (objConexaoDb.sqlConnection.ConnectionString  == "")
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlConn"].ConnectionString);
            }
            return sqlConnection;
        }

        public void CloseConn()
        {
            objConexaoDb = null;
        }
        
    }
}
