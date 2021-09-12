using DBStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStore.DAO
{
    public class OrderDAO
    {
        public static List<OrderDTO> GetListTable(string id = null)
        {
            var result = new List<OrderDTO>();
            const string sql = "select * from Order_";
            var table = DBAcess.GetDataTableBySQLString(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                result.Add(new OrderDTO(table.Rows[i]));
            }
            return result;
        }
        public static OrderDTO GetTable(string id)
        {
            return GetListTable().Where(i => i.Id == id).FirstOrDefault();
        }
        public static bool InsertTable(OrderDTO table)
        {
            string sql = $"insert into Order_(ProductId,CustomerId,OrderDate,Quantity,PricePaid,ShippedDate)" +
                $"values(N'{table.ProductId}',N'{table.CustomerId}',N'{table.OrderDate}',N'{table.Quantity}',N'{table.PricePaid}',N'{table.ShippedDate}')";
            return DBAcess.UpdateDataBySQLString(sql);
        }
        public static bool UpdateTable(OrderDTO table)
        {
            string sql = $"update Order_ set ProductId=N'',CustomerId=N''," +
                $"OrderDate=N'',Quantity=N'',PricePaid=N'',ShippedDate=N'' where id= N'{table.Id}'";
            return DBAcess.UpdateDataBySQLString(sql);
        }
        public static bool DeleteTable(string id)
        {
            string sql = $"delete Order_ where id=N'{id}'";
            return DBAcess.UpdateDataBySQLString(sql);
        }
    }
}
