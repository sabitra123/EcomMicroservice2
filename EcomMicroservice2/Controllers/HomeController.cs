using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using EcomMicroservice2.Models;

namespace EcomMicroservice2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AddHeader("Access-Control-Allow-Origin", "*")]
    public class HomeController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        public HomeController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
              DatabaseCURD dbCurd = new DatabaseCURD();
              List<ProductSegmentClass> lst = dbCurd.GetSegmentProduct(Configuration["ConnectionStrings:Default"]);
              return new JsonResult(lst); 
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            List<ProductMenuDetails> lst = new List<ProductMenuDetails>();
            DatabaseCURD dbCurd = new DatabaseCURD();
            lst = dbCurd.GetMenuDetails(Configuration["ConnectionStrings:Default"],id);

            return new JsonResult(lst);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
