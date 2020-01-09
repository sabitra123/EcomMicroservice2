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
    public class DiscountController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        public DiscountController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        // JsonResult
        //Family,Class,Commodity,Color,Brand
        [HttpGet("{Discount}")]
        public JsonResult Get(decimal Discount)
        {
            
            DatabaseCURD dbCurd = new DatabaseCURD();
            List<ProductDetailsClass> lst = dbCurd.GetDiscountDetailsAll(Configuration["ConnectionStrings:Default"],Discount);
            // string query = dbCurd.GetProductDetails(Configuration["ConnectionStrings:Default"],Family,Class,Commodity,Color,Brand);
              return new JsonResult(lst);  //dbCurd.GetAllProduct(Configuration["ConnectionStrings:Default"]);
              //return "value";            
        }

        [HttpGet]
        public JsonResult Get()
        {   
            DatabaseCURD dbCurd = new DatabaseCURD();
            List<decimal> lst = dbCurd.GetDistinctDiscount(Configuration["ConnectionStrings:Default"]);
            // string query = dbCurd.GetProductDetails(Configuration["ConnectionStrings:Default"],Family,Class,Commodity,Color,Brand);
              return new JsonResult(lst);  //dbCurd.GetAllProduct(Configuration["ConnectionStrings:Default"]);
              //return "value";            
        }

        
    }
}