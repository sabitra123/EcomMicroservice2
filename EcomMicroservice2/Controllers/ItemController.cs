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
    public class ItemController : ControllerBase
    {
        public IConfiguration Configuration { get; }
        public ItemController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }
        // JsonResult
        //Family,Class,Commodity,Color,Brand
        [HttpGet("{Item}")]
        public JsonResult Get(Int32 Item)
        {
            
            DatabaseCURD dbCurd = new DatabaseCURD();
            List<ProductDetailsClass> lst = dbCurd.GetItemDetailsAll(Configuration["ConnectionStrings:Default"],Item);
            // string query = dbCurd.GetProductDetails(Configuration["ConnectionStrings:Default"],Family,Class,Commodity,Color,Brand);
              return new JsonResult(lst);  //dbCurd.GetAllProduct(Configuration["ConnectionStrings:Default"]);
              //return "value";            
        }

        
        
    }
}