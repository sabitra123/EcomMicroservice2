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
    public class SearchController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        public SearchController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        // JsonResult
        //Family,Class,Commodity,Color,Brand
        [HttpGet("{SearchValue}")]
        public JsonResult Get(string SearchValue)
        {
            DatabaseCURD dbCurd = new DatabaseCURD();
            //result = dbCurd.GetSearchProductDetails(Configuration["ConnectionStrings:Default"],SearchValue);
            List<ProductDetailsClass> lst = dbCurd.GetSearchProductDetails(Configuration["ConnectionStrings:Default"],SearchValue);
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
