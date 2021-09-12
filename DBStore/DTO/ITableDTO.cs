using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBStore.DTO
{
    public interface ITableDTO
    {
        string Id { get; set; }
        string Name { get; set; }

    }
    public abstract class TableClassDTO : ITableDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
