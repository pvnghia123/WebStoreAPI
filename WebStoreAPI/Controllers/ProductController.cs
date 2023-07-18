using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebStoreAPI.Interface;
using WebStoreAPI.Models;
using WebStoreAPI.Interface;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using WebStoreAPI.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebStoreAPI.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    [Log(1)]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _IProduct;
        string text = "sdfsdf";
        public ProductController(IProduct iProduct)
        {
            _IProduct = iProduct;
        }

        // GET: api/<ProductController>
        [HttpGet]
        // [Authorize(policy:"admin")]
        //[OutputCache(Duration = 10)]
       // [ClaimRequirement("Roles", "role:Search")]
        public ActionResult<IEnumerable<Product>>  Get()
        {
            return  Ok(_IProduct.getAllProduct());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
