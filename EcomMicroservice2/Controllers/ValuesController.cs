using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace EcomMicroservice2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public IConfiguration Configuration { get; }
        public ValuesController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            try{
            using (MySqlConnection conn = GetConnection())  
                {  
                    conn.Open();  
                    MySqlCommand cmd = new MySqlCommand("select * from XXIBM_PRODUCT_CATALOG LIMIT 10", conn);                
                }
            return "value";
            }
            catch(Exception ex)
            {
               return ex.InnerException + ex.Message + ex.StackTrace + Configuration["ConnectionStrings:Default"];
            }
        }

        private MySqlConnection GetConnection()    
        {    
            return new MySqlConnection(Configuration["ConnectionStrings:Default"]);    
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
