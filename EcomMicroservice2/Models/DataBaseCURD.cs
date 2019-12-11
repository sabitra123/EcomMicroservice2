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
        public List<ProductDistinctClass> GetAllProduct(string connectionString)
        {
            List<ProductDistinctClass> lstProduct =  new List<ProductDistinctClass>();
            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  
                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getDistinctProduct, conn);                
                    conn.Open();
                    MySqlDataReader dataReader = cmd.ExecuteReader();
 
                    while (dataReader.Read())  
                    {  
                        ProductDistinctClass pdc = new ProductDistinctClass();

			           pdc.SegmentName = Convert.ToString(dataReader["SEGMENT_NAME"]);        
                       pdc.FamilyName = Convert.ToString(dataReader["FAMILY_NAME"]);   
                       pdc.ClassName =  Convert.ToString(dataReader["CLASS_NAME"]);

                       lstProduct.Add(pdc);
                       pdc.Dispose();
                       
                    }  

                    conn.Close();

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