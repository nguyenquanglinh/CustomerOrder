using DBStore.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStore.DAO
{
    public class ProductDAO
    {
        public static List<ProductDTO> GetListTable()
        {
            var result = new List<ProductDTO>();
            const string sql = "select * from Product";
            var table = DBAcess.GetDataTableBySQLString(sql);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                result.Add(new ProductDTO(table.Rows[i]));
            }
            return result;
        }
        public static ProductDTO GetTable(string id)
        {
            return GetListTable().Where(i => i.Id == id).FirstOrDefault();
        }
        public static bool InsertTable(ProductDTO table)
        {
            string sql = $"insert into Product(Name,PricePerItem,AverageCustomerRating)" +
                $"values(N'{table.Name}',N'{table.PricePerItem}',N'{table.AverageCustomerRating}')";
            return DBAcess.UpdateDataBySQLString(sql);
        }
        public static bool UpdateTable(ProductDTO table)
        {
            string sql = $"update Product set Name=N'{table.Name}',PricePerItem=N'{table.PricePerItem}'" +
                $",AverageCustomerRating=N'{table.AverageCustomerRating}'where id=N'{table.Id}'";
            return DBAcess.UpdateDataBySQLString(sql);
        }
        public static bool DeleteTable(string id)
        {
            string sql = $"delete Product where id=N'{id}'";
            return DBAcess.UpdateDataBySQLString(sql);
        }
    }
}
