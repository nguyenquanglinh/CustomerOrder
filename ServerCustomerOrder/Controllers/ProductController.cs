using DBStore.DAO;
using DBStore.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerProductOrder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public List<ProductDTO> GetListTable()
        {
            return ProductDAO.GetListTable();
        }
        [HttpGet("{id}")]
        public ProductDTO GetTable(string id)
        {
            return ProductDAO.GetTable(id);
        }

        [HttpPost]
        public bool InsertTable(ProductDTO table)
        {
            return ProductDAO.InsertTable(table);
        }

        [HttpPut]
        public bool UpdateTable(ProductDTO table)
        {
            return ProductDAO.UpdateTable(table);
        }

        [HttpDelete]
        public bool DeleteTable(string id)
        {
            return ProductDAO.DeleteTable(id);
        }
    }
}
