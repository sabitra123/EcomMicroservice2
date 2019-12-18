using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Text;

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

			         //  pdc.ITEM_NO = Convert.ToInt32(dataReader["ITEM_NUMBER"]);        
                     //  pdc.DESCRIPTION = Convert.ToString(dataReader["DESCRIPTION"]);   
                     //  pdc.CATALOGUE_CATEGORY = Convert.ToInt32(dataReader["CATALOGUE_CATEGORY"]);        
                     //  pdc.LONG_DESCRIPTION = Convert.ToString(dataReader["LONG_DESCRIPTION"]);       
                       pdc.BRAND = Convert.ToString(dataReader["BRAND"]);
                       
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
        // List<ProductDetailsClass>
        public string GetProductDetails(string connectionString,Int32 Family,Int32 Class,Int32 Commodity,string Color,string Brand)
        {
            string QueryRes = string.Empty;
            List<ProductDetailsClass> lstProduct =  new List<ProductDetailsClass>();

            StringBuilder sbQuery = new StringBuilder(QueryStringClass.getAllProductWithDetails);

            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  

                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getAllProductWithDetails, conn);                
                    
                    if(Family != 0)
                    {
                        sbQuery.Append(" AND CATALOGUE.FAMILY=@FAMILY ");
                        cmd.Parameters.AddWithValue("@FAMILY", Family);
                    }

                    if(Class != 0)
                    {
                        sbQuery.Append(" AND CATALOGUE.CLASS=@CLASS ");
                        cmd.Parameters.AddWithValue("@CLASS", Class);
                    }

                    if(Commodity != 0)
                    {
                        sbQuery.Append(" AND CATALOGUE.COMMODITY=@COMMODITY ");
                        cmd.Parameters.AddWithValue("@COMMODITY", Commodity);
                    }
                    // Color,string Brand
                    if(!String.IsNullOrEmpty(Color))
                    {
                        sbQuery.Append(" AND SKU.SKU_ATTRIBUTE_VALUE2=@COLOR ");
                        cmd.Parameters.AddWithValue("@COLOR", Color);
                    }

                    if(!String.IsNullOrEmpty(Brand))
                    {
                        sbQuery.Append(" AND STYLE.BRAND=@BRAND ");
                        cmd.Parameters.AddWithValue("@BRAND", Brand);
                    }
                    
                    cmd.CommandText = sbQuery.ToString();

                    conn.Open();
                    cmd.Prepare();

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())  
                    {  
                       ProductDetailsClass pdc = new ProductDetailsClass();
       
                       pdc.FAMILY_NAME = Convert.ToString(dataReader["FAMILY_NAME"]); 
                       pdc.CLASS_NAME = Convert.ToString(dataReader["CLASS_NAME"]); 
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
                return QueryRes; //lstProduct;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace+ex.Message);
                return QueryRes+ex.StackTrace+ex.Message;//lstProduct;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace+ex.Message);
                return QueryRes+ex.StackTrace+ex.Message; //lstProduct;
            }
        }


        public List<ProductMenuDetails> GetMenuDetails(string connectionString , Int32 segmentID)
        {
            List<ProductMenuDetails> lstProduct =  new List<ProductMenuDetails>();
            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  
                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getAllMenuDetails, conn);                
                    conn.Open();

                    cmd.Parameters.AddWithValue("@SEGMENT", segmentID);
                    cmd.Prepare();

                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    Int64 familyId = 0 ;
                    ProductMenuDetails pdc = null;
                    List<ProductClassClass> lstLocal = null;
 
                    while (dataReader.Read())  
                    {  
                        
                        if(familyId == 0 || familyId != Convert.ToInt32(dataReader["FAMILY"]))
                        {       
                            if(pdc != null && lstLocal != null)       
                            {
                                pdc.lst = lstLocal;
                                lstProduct.Add(pdc);
                            }

                            pdc = new ProductMenuDetails();
                            lstLocal = new List<ProductClassClass>(); 

                            pdc.FAMILY = Convert.ToInt32(dataReader["FAMILY"]); 
                            pdc.FAMILY_NAME = Convert.ToString(dataReader["FAMILY_NAME"]);

                            ProductClassClass pcc = new ProductClassClass();
                            pcc.CLASS_NAME = Convert.ToString(dataReader["CLASS_NAME"]);
                            pcc.CLASS = Convert.ToInt32(dataReader["CLASS"]); 
                            lstLocal.Add(pcc);
                          
                            familyId =  Convert.ToInt32(dataReader["FAMILY"]);
                        }  
                        else if(pdc != null && lstLocal != null)
                        {
                            ProductClassClass pcc = new ProductClassClass();
                            pcc.CLASS_NAME = Convert.ToString(dataReader["CLASS_NAME"]);
                            pcc.CLASS = Convert.ToInt32(dataReader["CLASS"]); 
                            lstLocal.Add(pcc);
                        }
                    }  
                    if(pdc != null && lstLocal != null)       
                    {
                        pdc.lst = lstLocal;
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