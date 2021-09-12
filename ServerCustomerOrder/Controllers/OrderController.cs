using DBStore.DAO;
using DBStore.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCustomerOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public List<OrderDTO> GetListTable()
        {
            return OrderDAO.GetListTable();
        }
        [HttpGet("{id}")]
        public OrderDTO GetTable(string id)
        {
            return OrderDAO.GetTable(id);
        }

        [HttpPost]
        public bool InsertTable(OrderDTO table)
        {
            return OrderDAO.InsertTable(table);
        }

        [HttpPut]
        public bool UpdateTable(OrderDTO table)
        {
            return OrderDAO.UpdateTable(table);
        }

        [HttpDelete]
        public bool DeleteTable(string id)
        {
            return OrderDAO.DeleteTable(id);
        }
    }
}
