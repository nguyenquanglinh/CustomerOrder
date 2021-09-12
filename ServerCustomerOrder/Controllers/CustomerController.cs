using DBStore.DTO;
using DBStore.DAO;
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
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public List<CustomerDTO> GetListTable()
        {
            return CustomerDAO.GetListTable();
        }
        [HttpGet("{id}")]
        public CustomerDTO GetTable(string id)
        {
            return CustomerDAO.GetTable(id);
        }

        [HttpPost]
        public bool InsertTable(CustomerDTO table)
        {
            return CustomerDAO.InsertTable(table);
        }

        [HttpPut]
        public bool UpdateTable(CustomerDTO table)
        {
            return CustomerDAO.UpdateTable(table);
        }

        [HttpDelete]
        public bool DeleteTable(string id)
        {
            return CustomerDAO.DeleteTable(id);
        }
    }
}
