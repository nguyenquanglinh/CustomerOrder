using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStore.DTO
{
    public class ProductDTO : TableClassDTO
    {
        public ProductDTO(DataRow dataRow)
        {
            try
            {
                Id= dataRow["id"].ToString().Trim();
                Name = dataRow["Name"].ToString().Trim();
                PricePerItem = float.Parse(dataRow["PricePerItem"].ToString().Trim());
                AverageCustomerRating = float.Parse(dataRow["AverageCustomerRating"].ToString().Trim());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public ProductDTO() { }
        public float PricePerItem { get; set; }
        public float AverageCustomerRating { get; set; }
    }
}
