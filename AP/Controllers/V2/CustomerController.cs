using AP.Dao;
using AP.Model.BO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP.Controllers.V2
{
    [ApiController]
    [ApiVersion("2.0")]
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
            var spName = "InsertCustomer.v2";
            DatabaseHelper.Insert<Customer>(spName, customer);
        }
    }
}
