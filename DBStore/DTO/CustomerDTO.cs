using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStore.DTO
{
    public class CustomerDTO : TableClassDTO
    {
        public CustomerDTO(DataRow dataRow)
        {
            try
            {
                Id = dataRow["Id"].ToString().Trim();
                Name = dataRow["Name"].ToString().Trim();
                Line1 = dataRow["Line1"].ToString().Trim();
                Line2 = dataRow["Line2"].ToString().Trim();
                City = dataRow["City"].ToString().Trim();
                State = dataRow["State"].ToString().Trim();
                Zip = dataRow["Zip"].ToString().Trim();
                Country = dataRow["Country"].ToString().Trim();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public CustomerDTO() { }

        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }
}
