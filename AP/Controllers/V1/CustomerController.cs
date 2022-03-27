using AP.Dao;
using AP.Model.BO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/Customer")]
    public class CustomerController : ControllerBase
    {
        public CustomerController() { }

        [HttpGet]
        public IEnumerable<Customer> Get(int? id)
        {
            var spName = "SelectCustomer";
            return DatabaseHelper.Query<dynamic, Customer>(spName, new { Id = id });
        }

        [HttpPost]
        public void Post(Customer customer)
        {
            var spName = "InsertCustomer";
            DatabaseHelper.Insert<Customer>(spName, customer);
        }
    }
}
