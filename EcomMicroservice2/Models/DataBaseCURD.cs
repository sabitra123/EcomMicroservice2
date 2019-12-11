using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace EcomMicroservice2.Models
{
    public class DatabaseCURD
    {
        public List<ProductClass> GetAllProduct(string connectionString)
        {
            List<ProductClass> lstProduct =  new List<ProductClass>();
            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  
                      
                    MySqlCommand cmd = new MySqlCommand("select * from XXIBM_PRODUCT_CATALOG LIMIT 10", conn);                
                    conn.Open();
                    MySqlDataReader dataReader = cmd.ExecuteReader();
 
                    while (dataReader.Read())  
                    {  
                        ProductClass pdc = new ProductClass();
                        pdc.Segment = Convert.ToInt32(dataReader["Segment"]);
                        pdc.SegmentName = Convert.ToString(dataReader["Segment Name"]);
                        pdc.Family = Convert.ToInt32(dataReader["Family"]);
                        pdc.FamilyName = Convert.ToString(dataReader["Family Name"]);
                        pdc.Class = Convert.ToInt32(dataReader["Class"]);
                        pdc.ClassName = Convert.ToString(dataReader["Class Name"]);
                        pdc.Commodity = Convert.ToInt32(dataReader["Commodity"]);
                        pdc.CommodityName = Convert.ToString(dataReader["Commodity Name"]);

                       lstProduct.Add(pdc);
                       pdc.Dispose();
                       
                    }  

                }
                return lstProduct;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace+ex.Message);
                return lstProduct;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace+ex.Message);
                return lstProduct;
            }
        }

        private MySqlConnection GetConnection(string connectionSt)    
        {    
           return new MySqlConnection(connectionSt); 
        } 
    }
}