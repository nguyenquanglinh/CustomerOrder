using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStore.DTO
{
    public class OrderDTO : TableClassDTO
    {
        public OrderDTO(DataRow dataRow)
        {
            try
            {
                Id =dataRow["Id"].ToString().Trim();
                ProductId = int.Parse(dataRow["ProductId"].ToString().Trim());
                CustomerId = int.Parse(dataRow["CustomerId"].ToString().Trim());
                Quantity = float.Parse(dataRow["Quantity"].ToString().Trim());
                PricePaid = float.Parse(dataRow["PricePaid"].ToString().Trim());
                OrderDate = DateTime.ParseExact(
                          s: dataRow["ProductId"].ToString().Trim(),
                          format: "dd/MM/yyyy HH:mm:ss",
                          provider: CultureInfo.GetCultureInfo("tr-TR"));
                ShippedDate = DateTime.ParseExact(
                          s: dataRow["ShippedDate"].ToString().Trim(),
                          format: "dd/MM/yyyy HH:mm:ss",
                          provider: CultureInfo.GetCultureInfo("tr-TR"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public OrderDTO() { }

        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public float Quantity { get; set; }
        public float PricePaid { get; set; }
        public DateTime ShippedDate { get; set; }
    }
}
