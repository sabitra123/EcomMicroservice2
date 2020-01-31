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
        public ActionResult<string> Get(string SearchValue)
        {
            DatabaseCURD dbCurd = new DatabaseCURD();
            string result =  dbCurd.GetSearchProductDetails(Configuration["ConnectionStrings:Default"],SearchValue);
            return result;
            //List<ProductDetailsClass> lst = dbCurd.GetSearchProductDetails(Configuration["ConnectionStrings:Default"],SearchValue);
            //return new JsonResult(lst);  
        }

        [HttpGet("{Color}/{Brand}/{Size}/{SearchValue}")]
        public JsonResult Get(string Color,string Brand, string Size, string SearchValue)
        {
            
            DatabaseCURD dbCurd = new DatabaseCURD();
            List<ProductDetailsClass> lst = dbCurd.GetSearchProductDetailsWFilter(Configuration["ConnectionStrings:Default"],Color,Brand,Size,SearchValue);
            // string query = dbCurd.GetProductDetails(Configuration["ConnectionStrings:Default"],Family,Class,Commodity,Color,Brand);
              return new JsonResult(lst);  //dbCurd.GetAllProduct(Configuration["ConnectionStrings:Default"]);
              //return "value";
            
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
