using System;

namespace DBStore
{
    class Program
    {
        static void Main(string[] args)
        {
            DBAcess.GetDataTableBySQLString("Select * from Product order by PricePerItem asc");
        }
    }
}
