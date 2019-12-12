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
        public List<ProductSegmentClass> GetSegmentProduct(string connectionString)
        {
            List<ProductSegmentClass> lstProduct =  new List<ProductSegmentClass>();
            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  
                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getDistinctSegmentProduct, conn);                
                    conn.Open();
                    MySqlDataReader dataReader = cmd.ExecuteReader();
 
                    while (dataReader.Read())  
                    {  
                        ProductSegmentClass pdc = new ProductSegmentClass();

			           pdc.SegmentName = Convert.ToString(dataReader["SEGMENT_NAME"]);        
                       pdc.Segment = Convert.ToInt32(dataReader["SEGMENT"]);   
                       
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

        public List<ProductBrandClass> GetAllBrand(string connectionString)
        {
            List<ProductBrandClass> lstProduct =  new List<ProductBrandClass>();
            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  
                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getDistinctBrandProduct, conn);                
                    conn.Open();
                    MySqlDataReader dataReader = cmd.ExecuteReader();
 
                    while (dataReader.Read())  
                    {  
                        ProductBrandClass pdc = new ProductBrandClass();

			           pdc.ITEM_NO = Convert.ToInt32(dataReader["ITEM_NO"]);        
                       pdc.DESCRIPTION = Convert.ToString(dataReader["DESCRIPTION"]);   
                       pdc.CATALOGUE_CATEGORY = Convert.ToInt32(dataReader["CATALOGUE_CATEGORY"]);        
                       pdc.LONG_DESCRIPTION = Convert.ToString(dataReader["LONG_DESCRIPTION"]);       
                       pdc.DESCRIPTION = Convert.ToString(dataReader["BRAND"]);
                       
                       lstProduct.Add(pdc);  
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

        public List<ProductClassClass> GetClassByID(string connectionString, Int32 familyId)
        {
            List<ProductClassClass> lstProduct =  new List<ProductClassClass>();
            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  
                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getDistinctClassProduct, conn);                
                    conn.Open();
                    cmd.Parameters.AddWithValue("@FAMILY", familyId);
                    cmd.Prepare();
                    MySqlDataReader dataReader = cmd.ExecuteReader();
 
                    while (dataReader.Read())  
                    {  
                        ProductClassClass pdc = new ProductClassClass();

			           pdc.CLASS_NAME = Convert.ToString(dataReader["CLASS_NAME"]);        
                       pdc.CLASS = Convert.ToInt32(dataReader["CLASS"]);   
                       
                       lstProduct.Add(pdc);
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

        public List<ProductFamilyClass> GetFamilyByID(string connectionString, Int32 SegmentId)
        {
            List<ProductFamilyClass> lstProduct =  new List<ProductFamilyClass>();
            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  
                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getDistinctFamilyProduct, conn);                
                    conn.Open();
                    cmd.Parameters.AddWithValue("@SEGMENT", SegmentId);
                    cmd.Prepare();
                    MySqlDataReader dataReader = cmd.ExecuteReader();
 
                    while (dataReader.Read())  
                    {  
                        ProductFamilyClass pdc = new ProductFamilyClass();

			           pdc.FAMILY_NAME = Convert.ToString(dataReader["FAMILY_NAME"]);        
                       pdc.FAMILY = Convert.ToInt32(dataReader["FAMILY"]);   
                       
                       lstProduct.Add(pdc);
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

        public List<ProductcommodityClass> GetCommodityByID(string connectionString, Int32 classId)
        {
            List<ProductcommodityClass> lstProduct =  new List<ProductcommodityClass>();
            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  
                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getDistinctCommodityProduct, conn);                
                    conn.Open();
                    cmd.Parameters.AddWithValue("@CLASS", classId);
                    cmd.Prepare();
                    MySqlDataReader dataReader = cmd.ExecuteReader();
 
                    while (dataReader.Read())  
                    {  
                        ProductcommodityClass pdc = new ProductcommodityClass();

			           pdc.COMMODITY_NAME = Convert.ToString(dataReader["COMMODITY_NAME"]);        
                       pdc.COMMODITY = Convert.ToInt32(dataReader["COMMODITY"]);   
                       
                       lstProduct.Add(pdc);
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

        public List<ProductDetailsClass> GetProductDetails(string connectionString)
        {
            List<ProductDetailsClass> lstProduct =  new List<ProductDetailsClass>();
            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  
                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getAllProductWithDetails, conn);                
                    conn.Open();
                    MySqlDataReader dataReader = cmd.ExecuteReader();
 
                    while (dataReader.Read())  
                    {  
                       ProductDetailsClass pdc = new ProductDetailsClass();
       
                       pdc.COMMODITY = Convert.ToInt32(dataReader["COMMODITY"]); 
                       pdc.COMMODITY_NAME = Convert.ToString(dataReader["COMMODITY_NAME"]);  
                       pdc.ITEM_NUMBER = Convert.ToInt32(dataReader["ITEM_NUMBER"]);  
                       pdc.DESCRIPTION = Convert.ToString(dataReader["DESCRIPTION"]);
                       pdc.LONG_DESCRIPTION = Convert.ToString(dataReader["LONG_DESCRIPTION"]);
                       pdc.BRAND = Convert.ToString(dataReader["BRAND"]);
                       pdc.SIZE = Convert.ToString(dataReader["SIZE"]);
                       pdc.COLOUR = Convert.ToString(dataReader["COLOUR"]);
                       pdc.LIST_PRICE = Convert.ToDecimal(dataReader["LIST_PRICE"]);
                       pdc.DISCOUNT = Convert.ToDecimal(dataReader["DISCOUNT"]);
                       pdc.INSTOCK = Convert.ToString(dataReader["INSTOCK"]);
                       pdc.PRICE_EFFECTIVE_DATE = Convert.ToDateTime(dataReader["PRICE_EFFECTIVE_DATE"]);


                       
                       lstProduct.Add(pdc);
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