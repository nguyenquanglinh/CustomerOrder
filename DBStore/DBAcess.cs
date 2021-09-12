using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStore
{
    public class DBAcess
    {
        #region parameter connection
        private static SqlConnection connection = new SqlConnection();
        private static string strConnString = "Data Source =" + @".\SQLEXPRESS;Database = CustomerOrders; Integrated Security=SSPI;";
        public static void SetConnectString(string connect)
        {
            CloseConnect();
            strConnString = connect;
            OpenConnect();
        }
        #endregion
        #region function basic 
        private static void OpenConnect()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = strConnString;
                    connection.Open();
                }
            }
            catch
            {
                throw new Exception("Khong the mo duoc cong ket noi");
            }
        }
        public static bool CloseConnect()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                return true;
            }
            catch
            {
                throw new Exception("Khong the huy cong ket noi");
            }
        }
        public static DataTable GetDataTableBySQLString(string Sql)
        {
            OpenConnect();
            var ada = new SqlDataAdapter(Sql, connection);
            var dta = new DataTable();
            ada.Fill(dta);
            return dta;
        }
        public static bool UpdateDataBySQLString(string sql)
        {
            try
            {
                OpenConnect();
                var cmd = new SqlCommand(sql, connection);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }
        #endregion
    }
}
