using BusinessModel.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace APITEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        
        [HttpGet("categories")]        
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<string>> Get()
        {
            var categories = _customerService.GetCategories();
            if (categories == null || !categories.Any())
            {
                return BadRequest("No Records Found");
            }
            return Ok(new { Result = categories});          
        }

        
        [HttpGet("customers/{id}")]
        [ProducesResponseType(typeof(IEnumerable), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<string>> Customers(int id)
        {
              var customers = _customerService.GetCustomers(id);
            if (customers == null || !customers.Any())
            {
                return BadRequest("No Records Found");
            }
            return Ok(new { Result = customers });  
        }        
    }
}
