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
    public class ProductDetailsController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        public ProductDetailsController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        // JsonResult
        //Family,Class,Commodity,Color,Brand
        [HttpGet("{Family}/{Class}/{Commodity}/{Color}/{Brand}")]
        public JsonResult Get(Int32 Family,Int32 Class,Int32 Commodity,string Color,string Brand)
        {
            
            DatabaseCURD dbCurd = new DatabaseCURD();
            List<ProductDetailsClass> lst = dbCurd.GetProductDetailsAll(Configuration["ConnectionStrings:Default"],Family,Class,Commodity,Color,Brand);
            // string query = dbCurd.GetProductDetails(Configuration["ConnectionStrings:Default"],Family,Class,Commodity,Color,Brand);
              return new JsonResult(lst);  //dbCurd.GetAllProduct(Configuration["ConnectionStrings:Default"]);
              //return "value";
            
        }

                //Family,Class,Commodity,Color,Brand
        [HttpGet("{Family}/{Class}/{Commodity}/{Color}")]
        public JsonResult Get(Int32 Family,Int32 Class,Int32 Commodity,string Color)
        {
            
              DatabaseCURD dbCurd = new DatabaseCURD();
             List<ProductDetailsClass> lst = dbCurd.GetProductDetailsExBrand(Configuration["ConnectionStrings:Default"],Family,Class,Commodity,Color);
            // string query = dbCurd.GetProductDetails(Configuration["ConnectionStrings:Default"],Family,Class,Commodity,Color,Brand);
              return new JsonResult(lst);  //dbCurd.GetAllProduct(Configuration["ConnectionStrings:Default"]);
              //return "value";
            
        }

        [HttpGet("{Family}/{Class}/{Commodity}")]
        public JsonResult Get(Int32 Family,Int32 Class,Int32 Commodity)
        {
            
              DatabaseCURD dbCurd = new DatabaseCURD();
             List<ProductDetailsClass> lst = dbCurd.GetProductDetailsExColor(Configuration["ConnectionStrings:Default"],Family,Class,Commodity);
            // string query = dbCurd.GetProductDetails(Configuration["ConnectionStrings:Default"],Family,Class,Commodity,Color,Brand);
              return new JsonResult(lst);  //dbCurd.GetAllProduct(Configuration["ConnectionStrings:Default"]);
              //return "value";
            
        }

        [HttpGet("{Family}/{Class}")]
        public ActionResult<string> Get(Int32 Family,Int32 Class)
        {
            
            DatabaseCURD dbCurd = new DatabaseCURD();
            //List<ProductDetailsClass> lst = dbCurd.GetProductDetailsExCommodity(Configuration["ConnectionStrings:Default"],Family,Class);
             string query = dbCurd.GetProductDetailsExCommodity(Configuration["ConnectionStrings:Default"],Family,Class);
              return query ;//new JsonResult(lst);  //dbCurd.GetAllProduct(Configuration["ConnectionStrings:Default"]);
              //return "value";
            
        }

        [HttpGet("{Family}")]
        public JsonResult Get(Int32 Family)
        {
            
            DatabaseCURD dbCurd = new DatabaseCURD();
            List<ProductDetailsClass> lst = dbCurd.GetProductDetailsExClass(Configuration["ConnectionStrings:Default"],Family);
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
