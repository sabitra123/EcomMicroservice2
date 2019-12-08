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
    public class HomeController : ControllerBase
    {
        public IConfiguration Configuration { get; }

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
            using (MySqlConnection conn = GetConnection())  
                {  
                    conn.Open();  
                    MySqlCommand cmd = new MySqlCommand("select * from XXIBM_PRODUCT_CATALOG LIMIT 10", conn);                
                }
            return "value";
        }

        public string ConnectionString { get; set; }      
    
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
