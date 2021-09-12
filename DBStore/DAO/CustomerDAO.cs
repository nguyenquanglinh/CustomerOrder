using DBStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStore.DAO
{
    public class CustomerDAO
    {
        public static List<CustomerDTO> GetListTable()
        {
            var result = new List<CustomerDTO>();
            const string sql = "select * from Customer";
            var table = DBAcess.GetDataTableBySQLString(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                result.Add(new CustomerDTO(table.Rows[i]));
            }
            return result;
        }
        public static CustomerDTO GetTable(string id)
        {
            return GetListTable().Where(i => i.Id == id).FirstOrDefault();
        }
        public static bool InsertTable(CustomerDTO table)
        {
            string sql = $"insert into Customer(Name,Line1,Line2,City,State,Zip,Country)values" +
                $"(N'{table.Name}',N'{table.Line1}',N'{table.Line2}',N'{table.City}',N'{table.State}',N'{table.Zip}',N'{table.Country}')";
            return DBAcess.UpdateDataBySQLString(sql);
        }
        public static bool UpdateTable(CustomerDTO table)
        {
            string sql = $"update Customer set Name=N'{table.Name}',Line1=N'{table.Line1}',Line2=N'{table.Line2}',City=N'{table.City}',Country=N'{table.Country}',State=N'{table.State}',Zip=N'{table.Zip}' where id=N'{table.Id}'";
            return DBAcess.UpdateDataBySQLString(sql);
        }
        public static bool DeleteTable(string id)
        {
            string sql = $"delete Customer where id=N'{id}'";
            return DBAcess.UpdateDataBySQLString(sql);
        }
    }
}
