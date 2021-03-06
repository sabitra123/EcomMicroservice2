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

        public List<ProductColorClass> GetAllColor(string connectionString)
        {
            List<ProductColorClass> lstProduct =  new List<ProductColorClass>();
            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  
                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getDistinctColorProduct, conn);                
                    conn.Open();
                    MySqlDataReader dataReader = cmd.ExecuteReader();
 
                    while (dataReader.Read())  
                    {  
                        ProductColorClass pdc = new ProductColorClass();

			         //  pdc.ITEM_NO = Convert.ToInt32(dataReader["ITEM_NUMBER"]);        
                     //  pdc.DESCRIPTION = Convert.ToString(dataReader["DESCRIPTION"]);   
                     //  pdc.CATALOGUE_CATEGORY = Convert.ToInt32(dataReader["CATALOGUE_CATEGORY"]);        
                     //  pdc.LONG_DESCRIPTION = Convert.ToString(dataReader["LONG_DESCRIPTION"]);       
                       pdc.COLOUR = Convert.ToString(dataReader["COLOUR"]);
                       
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

        public List<ProductSizeClass> GetAllSize(string connectionString)
        {
            List<ProductSizeClass> lstProduct =  new List<ProductSizeClass>();
            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  
                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getDistinctSizeProduct, conn);                
                    conn.Open();
                    MySqlDataReader dataReader = cmd.ExecuteReader();
 
                    while (dataReader.Read())  
                    {  
                        ProductSizeClass pdc = new ProductSizeClass();

			         //  pdc.ITEM_NO = Convert.ToInt32(dataReader["ITEM_NUMBER"]);        
                     //  pdc.DESCRIPTION = Convert.ToString(dataReader["DESCRIPTION"]);   
                     //  pdc.CATALOGUE_CATEGORY = Convert.ToInt32(dataReader["CATALOGUE_CATEGORY"]);        
                     //  pdc.LONG_DESCRIPTION = Convert.ToString(dataReader["LONG_DESCRIPTION"]);       
                       pdc.SIZE = Convert.ToString(dataReader["SIZE"]);
                       
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
        public List<ProductDetailsClass> GetProductDetailsAll(string connectionString,Int32 Family,Int32 Class,Int32 Commodity,string Color,string Brand, string Size)
        {
            List<ProductDetailsClass> lstProduct =  new List<ProductDetailsClass>();

            StringBuilder sbQuery = new StringBuilder();

            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  

                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getAllProductWithDetails, conn); 

                    sbQuery.Append(cmd.CommandText);               
                    
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
                        sbQuery.Append(" AND SKU.SKU_ATTRIBUTE_VALUE2 IN ( "+Color+" )");
                       // cmd.Parameters.AddWithValue("@COLOR", Color);
                    }

                    if(!String.IsNullOrEmpty(Brand))
                    {
                        sbQuery.Append(" AND STYLE.BRAND IN ( "+Brand+" )");
                      //  cmd.Parameters.AddWithValue("@BRAND", Brand);
                    }

                    if(!String.IsNullOrEmpty(Size))
                    {
                        sbQuery.Append(" AND SKU_ATTRIBUTE_VALUE1 IN ( "+Size+" )");
                       // cmd.Parameters.AddWithValue("@SIZE", Size);
                    }
                    sbQuery.Append("  ORDER BY FAMILY, CLASS, COMMODITY , SKU.STYLE_ITEM, SKU.ITEM_NUMBER, COMMODITY_NAME, BRAND, SKU_ATTRIBUTE_VALUE1 , SKU_ATTRIBUTE_VALUE2, LIST_PRICE, DISCOUNT, IN_STOCK, PRICE_EFFECTIVE_DATE, SKU.DESCRIPTION,SKU.LONG_DESCRIPTION ");

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
                       pdc.ITEM_NUMBER = dataReader["ITEM_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["ITEM_NUMBER"]);
                       pdc.DESCRIPTION = Convert.ToString(dataReader["DESCRIPTION"]);
                       pdc.LONG_DESCRIPTION = Convert.ToString(dataReader["LONG_DESCRIPTION"]);
                       pdc.BRAND = Convert.ToString(dataReader["BRAND"]);
                       pdc.SIZE = Convert.ToString(dataReader["SIZE"]);
                       pdc.COLOUR = Convert.ToString(dataReader["COLOUR"]);
                       pdc.LIST_PRICE = dataReader["LIST_PRICE"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["LIST_PRICE"]);
                       pdc.DISCOUNT = dataReader["DISCOUNT"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["DISCOUNT"]);
                       pdc.INSTOCK = Convert.ToString(dataReader["IN_STOCK"]);
                       pdc.PRICE_EFFECTIVE_DATE = dataReader["PRICE_EFFECTIVE_DATE"]   == DBNull.Value ? DateTime.Today : Convert.ToDateTime(dataReader["PRICE_EFFECTIVE_DATE"]);
                      
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


        public List<ProductDetailsClass> GetProductDetailsExBrand(string connectionString,Int32 Family,Int32 Class,Int32 Commodity,string Color)
        {
            List<ProductDetailsClass> lstProduct =  new List<ProductDetailsClass>();

            StringBuilder sbQuery = new StringBuilder();

            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  

                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getAllProductWithDetails, conn);                
                    sbQuery.Append(cmd.CommandText);

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
                        sbQuery.Append(" AND SKU.SKU_ATTRIBUTE_VALUE2 IN ( "+Color+" ) ");
                        //cmd.Parameters.AddWithValue("@COLOR", Color);
                    }
                    sbQuery.Append("  ORDER BY FAMILY, CLASS, COMMODITY , SKU.STYLE_ITEM, SKU.ITEM_NUMBER, COMMODITY_NAME, BRAND, SKU_ATTRIBUTE_VALUE1 , SKU_ATTRIBUTE_VALUE2, LIST_PRICE, DISCOUNT, IN_STOCK, PRICE_EFFECTIVE_DATE, SKU.DESCRIPTION,SKU.LONG_DESCRIPTION ");
                    
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
                       pdc.ITEM_NUMBER = dataReader["ITEM_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["ITEM_NUMBER"]);
                       pdc.DESCRIPTION = Convert.ToString(dataReader["DESCRIPTION"]);
                       pdc.LONG_DESCRIPTION = Convert.ToString(dataReader["LONG_DESCRIPTION"]);
                       pdc.BRAND = Convert.ToString(dataReader["BRAND"]);
                       pdc.SIZE = Convert.ToString(dataReader["SIZE"]);
                       pdc.COLOUR = Convert.ToString(dataReader["COLOUR"]);
                       pdc.LIST_PRICE = dataReader["LIST_PRICE"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["LIST_PRICE"]);
                       pdc.DISCOUNT = dataReader["DISCOUNT"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["DISCOUNT"]);
                       pdc.INSTOCK = Convert.ToString(dataReader["IN_STOCK"]);
                       pdc.PRICE_EFFECTIVE_DATE = dataReader["PRICE_EFFECTIVE_DATE"]   == DBNull.Value ? DateTime.Today : Convert.ToDateTime(dataReader["PRICE_EFFECTIVE_DATE"]);
                      
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

        public List<ProductDetailsClass> GetProductDetailsExColor(string connectionString,Int32 Family,Int32 Class,Int32 Commodity)
        {
            List<ProductDetailsClass> lstProduct =  new List<ProductDetailsClass>();

            StringBuilder sbQuery = new StringBuilder();

            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  

                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getAllProductWithDetails, conn); 
                    sbQuery.Append(cmd.CommandText);               
                    
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

                    sbQuery.Append("  ORDER BY FAMILY, CLASS, COMMODITY , SKU.STYLE_ITEM, SKU.ITEM_NUMBER, COMMODITY_NAME, BRAND, SKU_ATTRIBUTE_VALUE1 , SKU_ATTRIBUTE_VALUE2, LIST_PRICE, DISCOUNT, IN_STOCK, PRICE_EFFECTIVE_DATE, SKU.DESCRIPTION,SKU.LONG_DESCRIPTION ");
                    
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
                       pdc.ITEM_NUMBER = dataReader["ITEM_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["ITEM_NUMBER"]);
                       pdc.DESCRIPTION = Convert.ToString(dataReader["DESCRIPTION"]);
                       pdc.LONG_DESCRIPTION = Convert.ToString(dataReader["LONG_DESCRIPTION"]);
                       pdc.BRAND = Convert.ToString(dataReader["BRAND"]);
                       pdc.SIZE = Convert.ToString(dataReader["SIZE"]);
                       pdc.COLOUR = Convert.ToString(dataReader["COLOUR"]);
                       pdc.LIST_PRICE = dataReader["LIST_PRICE"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["LIST_PRICE"]);
                       pdc.DISCOUNT = dataReader["DISCOUNT"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["DISCOUNT"]);
                       pdc.INSTOCK = Convert.ToString(dataReader["IN_STOCK"]);
                       pdc.PRICE_EFFECTIVE_DATE = dataReader["PRICE_EFFECTIVE_DATE"]   == DBNull.Value ? DateTime.Today : Convert.ToDateTime(dataReader["PRICE_EFFECTIVE_DATE"]);
                      
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


        public List<ProductDetailsClass> GetProductDetailsExCommodity(string connectionString,Int32 Family,Int32 Class)
        {
            List<ProductDetailsClass> lstProduct =  new List<ProductDetailsClass>();

            StringBuilder sbQuery = new StringBuilder();

            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  

                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getAllProductWithDetails, conn); 
                    sbQuery.Append(cmd.CommandText);               
                    
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
                    
                    sbQuery.Append("  ORDER BY FAMILY, CLASS, COMMODITY , SKU.STYLE_ITEM, SKU.ITEM_NUMBER, COMMODITY_NAME, BRAND, SKU_ATTRIBUTE_VALUE1 , SKU_ATTRIBUTE_VALUE2, LIST_PRICE, DISCOUNT, IN_STOCK, PRICE_EFFECTIVE_DATE, SKU.DESCRIPTION,SKU.LONG_DESCRIPTION ");

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
                       pdc.ITEM_NUMBER = dataReader["ITEM_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["ITEM_NUMBER"]);
                       pdc.DESCRIPTION = Convert.ToString(dataReader["DESCRIPTION"]);
                       pdc.LONG_DESCRIPTION = Convert.ToString(dataReader["LONG_DESCRIPTION"]);
                       pdc.BRAND = Convert.ToString(dataReader["BRAND"]);
                       pdc.SIZE = Convert.ToString(dataReader["SIZE"]);
                       pdc.COLOUR = Convert.ToString(dataReader["COLOUR"]);
                       pdc.LIST_PRICE = dataReader["LIST_PRICE"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["LIST_PRICE"]);
                       pdc.DISCOUNT = dataReader["DISCOUNT"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["DISCOUNT"]);
                       pdc.INSTOCK = Convert.ToString(dataReader["IN_STOCK"]);
                       pdc.PRICE_EFFECTIVE_DATE = dataReader["PRICE_EFFECTIVE_DATE"]   == DBNull.Value ? DateTime.Today : Convert.ToDateTime(dataReader["PRICE_EFFECTIVE_DATE"]);
                      
                       lstProduct.Add(pdc);
                    }  

                    conn.Close();

                }
                return  lstProduct;
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


        public List<ProductDetailsClass> GetProductDetailsExClass(string connectionString,Int32 Family)
        {
            List<ProductDetailsClass> lstProduct =  new List<ProductDetailsClass>();

            StringBuilder sbQuery = new StringBuilder();

            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  

                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getAllProductWithDetails, conn);
                    sbQuery.Append(cmd.CommandText);                
                    
                    if(Family != 0)
                    {
                        sbQuery.Append(" AND CATALOGUE.FAMILY=@FAMILY ");
                        cmd.Parameters.AddWithValue("@FAMILY", Family);
                    }
                    sbQuery.Append("  ORDER BY FAMILY, CLASS, COMMODITY , SKU.STYLE_ITEM, SKU.ITEM_NUMBER, COMMODITY_NAME, BRAND, SKU_ATTRIBUTE_VALUE1 , SKU_ATTRIBUTE_VALUE2, LIST_PRICE, DISCOUNT, IN_STOCK, PRICE_EFFECTIVE_DATE, SKU.DESCRIPTION,SKU.LONG_DESCRIPTION ");

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
                       pdc.ITEM_NUMBER = dataReader["ITEM_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["ITEM_NUMBER"]);
                       pdc.DESCRIPTION = Convert.ToString(dataReader["DESCRIPTION"]);
                       pdc.LONG_DESCRIPTION = Convert.ToString(dataReader["LONG_DESCRIPTION"]);
                       pdc.BRAND = Convert.ToString(dataReader["BRAND"]);
                       pdc.SIZE = Convert.ToString(dataReader["SIZE"]);
                       pdc.COLOUR = Convert.ToString(dataReader["COLOUR"]);
                       pdc.LIST_PRICE = dataReader["LIST_PRICE"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["LIST_PRICE"]);
                       pdc.DISCOUNT = dataReader["DISCOUNT"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["DISCOUNT"]);
                       pdc.INSTOCK = Convert.ToString(dataReader["IN_STOCK"]);
                       pdc.PRICE_EFFECTIVE_DATE = dataReader["PRICE_EFFECTIVE_DATE"]   == DBNull.Value ? DateTime.Today : Convert.ToDateTime(dataReader["PRICE_EFFECTIVE_DATE"]);
                      
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

        public List<ProductDetailsClass> GetProductDetailsAllData(string connectionString)
        {
            string errorSt = string.Empty;
            List<ProductDetailsClass> lstProduct =  new List<ProductDetailsClass>();

            StringBuilder sbQuery = new StringBuilder();

            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  

                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getAllProductWithDetailsNoFilter, conn);
                    sbQuery.Append(cmd.CommandText);                
                    
                    sbQuery.Append("  ORDER BY FAMILY, CLASS, COMMODITY , SKU.STYLE_ITEM, SKU.ITEM_NUMBER, COMMODITY_NAME, BRAND, SKU_ATTRIBUTE_VALUE1 , SKU_ATTRIBUTE_VALUE2, LIST_PRICE, DISCOUNT, IN_STOCK, PRICE_EFFECTIVE_DATE, SKU.DESCRIPTION,SKU.LONG_DESCRIPTION ");

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
                       pdc.ITEM_NUMBER = dataReader["ITEM_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["ITEM_NUMBER"]);
                       pdc.DESCRIPTION = Convert.ToString(dataReader["DESCRIPTION"]);
                       pdc.LONG_DESCRIPTION = Convert.ToString(dataReader["LONG_DESCRIPTION"]);
                       pdc.BRAND = Convert.ToString(dataReader["BRAND"]);
                       pdc.SIZE = Convert.ToString(dataReader["SIZE"]);
                       pdc.COLOUR = Convert.ToString(dataReader["COLOUR"]);
                       pdc.LIST_PRICE = dataReader["LIST_PRICE"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["LIST_PRICE"]);
                       pdc.DISCOUNT = dataReader["DISCOUNT"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["DISCOUNT"]);
                       pdc.INSTOCK = Convert.ToString(dataReader["IN_STOCK"]);
                       pdc.PRICE_EFFECTIVE_DATE = dataReader["PRICE_EFFECTIVE_DATE"]   == DBNull.Value ? DateTime.Today : Convert.ToDateTime(dataReader["PRICE_EFFECTIVE_DATE"]);
                      
                       lstProduct.Add(pdc);
                    }  

                    conn.Close();

                }
                return lstProduct;
            }
            catch(MySqlException ex)
            {   
                errorSt = ex.StackTrace+ex.Message;
                Console.WriteLine(ex.StackTrace+ex.Message);
                return  lstProduct; //errorSt;
            }
            catch(Exception ex)
            {
                errorSt = ex.StackTrace+ex.Message;
                Console.WriteLine(ex.StackTrace+ex.Message);
                return lstProduct; //errorSt;
            }
        }


        public List<ProductDetailsClass> GetSearchProductDetails(string connectionString,string SearchValue)
        {
            //string result = string.Empty;
            List<ProductDetailsClass> lstProduct =  new List<ProductDetailsClass>();
            Dictionary<Int32,ProductDetailsClass> diTemp = new Dictionary<int, ProductDetailsClass>();
            Dictionary<Int32,ProductDetailsClass> diTemp2 = new Dictionary<int, ProductDetailsClass>();
            StringBuilder sbQuery = new StringBuilder();

            try{
                    using (MySqlConnection conn = GetConnection(connectionString))  
                    {  
                        string[] searchValues = SearchValue.Split(' ');
                        StringBuilder sbSearchSt = new StringBuilder();
                        bool _flag = false;

                        foreach(string value in searchValues)
                        {
                            sbQuery.Clear();
                            using(MySqlCommand cmd = new MySqlCommand(QueryStringClass.getSearchProductWithDetails, conn))
                            {
                                    sbQuery.Append(cmd.CommandText);

                                    if (!string.IsNullOrEmpty(value))
                                    {
                                        cmd.Parameters.AddWithValue("@VALUE", String.Format("%{0}%", value));
                                    }

                                    sbQuery.Append("  ORDER BY FAMILY, CLASS, COMMODITY , SKU.STYLE_ITEM, SKU.ITEM_NUMBER, COMMODITY_NAME, BRAND, SKU_ATTRIBUTE_VALUE1 , SKU_ATTRIBUTE_VALUE2 , LIST_PRICE, DISCOUNT, IN_STOCK, PRICE_EFFECTIVE_DATE, SKU.DESCRIPTION,SKU.LONG_DESCRIPTION ");

                                    cmd.CommandText = sbQuery.ToString();
                                    //result = sbQuery.ToString();
                                    if(conn.State != System.Data.ConnectionState.Open)
                                    { conn.Open(); }
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
                                        if(DBNull.Value != dataReader["LIST_PRICE"])
                                        {pdc.LIST_PRICE = Convert.ToDecimal(dataReader["LIST_PRICE"]);}
                                        else
                                        {
                                            pdc.LIST_PRICE = 0;
                                        }

                                        if(DBNull.Value != dataReader["DISCOUNT"])
                                        {pdc.DISCOUNT = Convert.ToDecimal(dataReader["DISCOUNT"]);}
                                        else
                                        {
                                            pdc.DISCOUNT = 0;
                                        }

                                        pdc.INSTOCK = Convert.ToString(dataReader["IN_STOCK"]);
                                        pdc.PRICE_EFFECTIVE_DATE = Convert.ToDateTime(dataReader["PRICE_EFFECTIVE_DATE"]);

                                        if (pdc.ITEM_NUMBER != 0 && _flag == false && !diTemp.ContainsKey(pdc.ITEM_NUMBER))
                                        {
                                            //result = "Adding"+ result;
                                            diTemp.Add(pdc.ITEM_NUMBER, pdc);
                                        }
                                        else if(pdc.ITEM_NUMBER != 0 && _flag == true && !diTemp2.ContainsKey(pdc.ITEM_NUMBER))
                                        {
                                                diTemp2.Add(pdc.ITEM_NUMBER, pdc);
                                        }

                                    }
                                    if(!dataReader.IsClosed)
                                    {
                                        dataReader.Close();
                                    }
                                //result = cmd.CommandText + " "+conn.ToString();;
                            }
                            if(diTemp.Count > 0 && diTemp2.Count > 0 &&  _flag == true)
                            {
                               //result = result + diTemp.Count+" 1st round "+diTemp2.Count;
                               diTemp = diTemp.Where(x => diTemp2.ContainsKey(x.Key)).ToDictionary(x => x.Key, x => x.Value);
                               //result = result + diTemp.Count +"2nd";
                               diTemp2.Clear();
                            }
                             _flag = true;
                        }                       
                    }
                    foreach(KeyValuePair<Int32,ProductDetailsClass> valueList in diTemp)
                    {
                        lstProduct.Add(valueList.Value);
                    }
                return lstProduct;
                //return diTemp.Count.ToString() + result;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace+ex.Message+"....."+diTemp.Count.ToString());
                //return ex.StackTrace+ex.Message+"....."+diTemp.Count.ToString()+ result;
                return lstProduct;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace+ex.Message);
                //return ex.StackTrace+ex.Message+"....."+diTemp.Count.ToString()+ result;
                return lstProduct;
            }
        }

        public List<ProductDetailsClass> GetSearchProductDetailsWFilter(string connectionString,string Color,string Brand, string Size, string SearchValue)
        {
            //string result = string.Empty;
            List<ProductDetailsClass> lstProduct =  new List<ProductDetailsClass>();
            Dictionary<Int32,ProductDetailsClass> diTemp = new Dictionary<int, ProductDetailsClass>();
            Dictionary<Int32,ProductDetailsClass> diTemp2 = new Dictionary<int, ProductDetailsClass>();
            StringBuilder sbQuery = new StringBuilder();

            try{
                    using (MySqlConnection conn = GetConnection(connectionString))  
                    {  
                        string[] searchValues = SearchValue.Split(' ');
                        StringBuilder sbSearchSt = new StringBuilder();
                        bool _flag = false;

                        foreach(string value in searchValues)
                        {
                            sbQuery.Clear();
                            
                            using(MySqlCommand cmd = new MySqlCommand(QueryStringClass.getSearchProductWithDetails, conn))
                            {
                                    sbQuery.Append(cmd.CommandText);

                                    if (!string.IsNullOrEmpty(value))
                                    {
                                        cmd.Parameters.AddWithValue("@VALUE", String.Format("%{0}%", value));
                                    }

                                    sbQuery.Append("  ORDER BY FAMILY, CLASS, COMMODITY , SKU.STYLE_ITEM, SKU.ITEM_NUMBER, COMMODITY_NAME, BRAND, SKU_ATTRIBUTE_VALUE1 , SKU_ATTRIBUTE_VALUE2 , LIST_PRICE, DISCOUNT, IN_STOCK, PRICE_EFFECTIVE_DATE, SKU.DESCRIPTION,SKU.LONG_DESCRIPTION ");

                                    cmd.CommandText = sbQuery.ToString();
                                    //result = sbQuery.ToString();
                                    if(conn.State != System.Data.ConnectionState.Open)
                                    { conn.Open(); }
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
                                        pdc.BRAND = Convert.ToString(dataReader["BRAND"]).ToLower();
                                        pdc.SIZE = Convert.ToString(dataReader["SIZE"]).ToLower();
                                        pdc.COLOUR = Convert.ToString(dataReader["COLOUR"]).ToLower();

                                        if(DBNull.Value != dataReader["LIST_PRICE"])
                                        {pdc.LIST_PRICE = Convert.ToDecimal(dataReader["LIST_PRICE"]);}
                                        else
                                        {
                                            pdc.LIST_PRICE = 0;
                                        }

                                        if(DBNull.Value != dataReader["DISCOUNT"])
                                        {pdc.DISCOUNT = Convert.ToDecimal(dataReader["DISCOUNT"]);}
                                        else
                                        {
                                            pdc.DISCOUNT = 0;
                                        }

                                        pdc.INSTOCK = Convert.ToString(dataReader["IN_STOCK"]);
                                        pdc.PRICE_EFFECTIVE_DATE = Convert.ToDateTime(dataReader["PRICE_EFFECTIVE_DATE"]);

                                        if (pdc.ITEM_NUMBER != 0 && _flag == false && !diTemp.ContainsKey(pdc.ITEM_NUMBER))
                                        {
                                            diTemp.Add(pdc.ITEM_NUMBER, pdc);
                                        }
                                        else if(pdc.ITEM_NUMBER != 0 && _flag == true && !diTemp2.ContainsKey(pdc.ITEM_NUMBER))
                                        {
                                            diTemp2.Add(pdc.ITEM_NUMBER, pdc);
                                        }

                                    }
                                    if(!dataReader.IsClosed)
                                    {
                                        dataReader.Close();
                                    }
                                //result = cmd.CommandText + " "+conn.ToString();;
                            }
                            if(diTemp.Count > 0 && diTemp2.Count > 0 &&  _flag == true)
                            {
                               diTemp = diTemp.Where(x => diTemp2.ContainsKey(x.Key)).ToDictionary(x => x.Key, x => x.Value);
                               diTemp2.Clear();
                            }
                             _flag = true;
                        }                       
                    }
                    foreach(KeyValuePair<Int32,ProductDetailsClass> valueList in diTemp)
                    {
                        lstProduct.Add(valueList.Value);
                    }
                            if (!String.IsNullOrEmpty(Color))
                            {
                                string[] _colorArray = Color.Split(',');
                                if(_colorArray.Length == 1)
                                {lstProduct = lstProduct.Where(x => x.COLOUR.Contains(Color.Replace("'","").ToLower())).ToList<ProductDetailsClass>();}
                                else
                                {
                                    List<ProductDetailsClass> _lstColor = new List<ProductDetailsClass>();
                                    foreach(string value in _colorArray)
                                    {
                                        List<ProductDetailsClass> _lstTempColor = new List<ProductDetailsClass>();
                                        _lstTempColor = lstProduct.Where(x => x.COLOUR.Contains(value.Replace("'","").ToLower())).ToList<ProductDetailsClass>();
                                        _lstColor.AddRange(_lstTempColor);
                                    }
                                    lstProduct = _lstColor;

                                }
                            }

                            if (!String.IsNullOrEmpty(Brand))
                            {
                                string[] _brandArray = Brand.Split(',');
                                if(_brandArray.Length == 1)
                                {lstProduct = lstProduct.Where(x => x.BRAND.Contains(Brand.Replace("'","").ToLower())).ToList<ProductDetailsClass>();}
                                else{
                                        List<ProductDetailsClass> _lstBrand = new List<ProductDetailsClass>();
                                        foreach(string value in _brandArray)
                                        {
                                            List<ProductDetailsClass> _lstTempBrand = new List<ProductDetailsClass>();
                                            _lstTempBrand = lstProduct.Where(x => x.BRAND.Contains(value.Replace("'","").ToLower())).ToList<ProductDetailsClass>();
                                            _lstBrand.AddRange(_lstTempBrand);
                                        }
                                        lstProduct = _lstBrand;
                                    }
                            }

                            if (!String.IsNullOrEmpty(Size))
                            {
                               string[] _sizeArray = Size.Split(',');
                               if(_sizeArray.Length == 1)
                               {lstProduct = lstProduct.Where(x => x.SIZE.Contains(Size.Replace("'","").ToLower())).ToList<ProductDetailsClass>();}
                               else
                               {
                                   List<ProductDetailsClass> _lstSize = new List<ProductDetailsClass>();
                                   foreach(string value in _sizeArray)
                                        {
                                            List<ProductDetailsClass> _lstTempSize = new List<ProductDetailsClass>();
                                            _lstTempSize = lstProduct.Where(x => x.SIZE.Contains(value.Replace("'","").ToLower())).ToList<ProductDetailsClass>();
                                            _lstSize.AddRange(_lstTempSize);
                                        }
                                        lstProduct = _lstSize;
                               }
                            }

                return lstProduct;
                //return diTemp.Count.ToString(); //result;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace+ex.Message+"....."+diTemp.Count.ToString());
                //return ex.StackTrace+ex.Message+"....."+diTemp.Count.ToString();
                return lstProduct;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace+ex.Message);
                //return ex.StackTrace+ex.Message+"....."+diTemp.Count.ToString();
                return lstProduct;
            }
        }


        
        public List<ProductDetailsClass> GetDiscountDetailsAll(string connectionString,decimal Discount)
        {
            List<ProductDetailsClass> lstProduct =  new List<ProductDetailsClass>();

            StringBuilder sbQuery = new StringBuilder();

            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  

                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getAllProductWithDetails, conn); 

                    sbQuery.Append(cmd.CommandText);               
                    

                    if(Discount != 0)
                    {
                        sbQuery.Append(" AND DISCOUNT = @Discount ");
                        cmd.Parameters.AddWithValue("@Discount", Discount);
                    }
                    sbQuery.Append("  ORDER BY FAMILY, CLASS, COMMODITY , SKU.STYLE_ITEM, SKU.ITEM_NUMBER, COMMODITY_NAME, BRAND, SKU_ATTRIBUTE_VALUE1 , SKU_ATTRIBUTE_VALUE2, LIST_PRICE, DISCOUNT, IN_STOCK, PRICE_EFFECTIVE_DATE, SKU.DESCRIPTION,SKU.LONG_DESCRIPTION ");

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
                       pdc.ITEM_NUMBER = dataReader["ITEM_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["ITEM_NUMBER"]);
                       pdc.DESCRIPTION = Convert.ToString(dataReader["DESCRIPTION"]);
                       pdc.LONG_DESCRIPTION = Convert.ToString(dataReader["LONG_DESCRIPTION"]);
                       pdc.BRAND = Convert.ToString(dataReader["BRAND"]);
                       pdc.SIZE = Convert.ToString(dataReader["SIZE"]);
                       pdc.COLOUR = Convert.ToString(dataReader["COLOUR"]);
                       pdc.LIST_PRICE = dataReader["LIST_PRICE"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["LIST_PRICE"]);
                       pdc.DISCOUNT = dataReader["DISCOUNT"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["DISCOUNT"]);
                       pdc.INSTOCK = Convert.ToString(dataReader["IN_STOCK"]);
                       pdc.PRICE_EFFECTIVE_DATE = dataReader["PRICE_EFFECTIVE_DATE"]   == DBNull.Value ? DateTime.Today : Convert.ToDateTime(dataReader["PRICE_EFFECTIVE_DATE"]);
                      
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

        public List<ProductDetailsClass> GetItemDetailsAll(string connectionString,Int32 Item)
        {
            List<ProductDetailsClass> lstProduct =  new List<ProductDetailsClass>();

            StringBuilder sbQuery = new StringBuilder();

            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  

                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getAllProductWithDetails, conn); 

                    sbQuery.Append(cmd.CommandText);               
                    

                    if(Item != 0)
                    {
                        sbQuery.Append(" AND SKU.ITEM_NUMBER = @Item ");
                        cmd.Parameters.AddWithValue("@Item", Item);
                    }
                    sbQuery.Append("  ORDER BY FAMILY, CLASS, COMMODITY , SKU.STYLE_ITEM, SKU.ITEM_NUMBER, COMMODITY_NAME, BRAND, SKU_ATTRIBUTE_VALUE1 , SKU_ATTRIBUTE_VALUE2, LIST_PRICE, DISCOUNT, IN_STOCK, PRICE_EFFECTIVE_DATE, SKU.DESCRIPTION,SKU.LONG_DESCRIPTION ");

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
                       pdc.ITEM_NUMBER = dataReader["ITEM_NUMBER"] == DBNull.Value ? 0 : Convert.ToInt32(dataReader["ITEM_NUMBER"]);
                       pdc.DESCRIPTION = Convert.ToString(dataReader["DESCRIPTION"]);
                       pdc.LONG_DESCRIPTION = Convert.ToString(dataReader["LONG_DESCRIPTION"]);
                       pdc.BRAND = Convert.ToString(dataReader["BRAND"]);
                       pdc.SIZE = Convert.ToString(dataReader["SIZE"]);
                       pdc.COLOUR = Convert.ToString(dataReader["COLOUR"]);
                       pdc.LIST_PRICE = dataReader["LIST_PRICE"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["LIST_PRICE"]);
                       pdc.DISCOUNT = dataReader["DISCOUNT"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["DISCOUNT"]);
                       pdc.INSTOCK = Convert.ToString(dataReader["IN_STOCK"]);
                       pdc.PRICE_EFFECTIVE_DATE = dataReader["PRICE_EFFECTIVE_DATE"]   == DBNull.Value ? DateTime.Today : Convert.ToDateTime(dataReader["PRICE_EFFECTIVE_DATE"]);
                      
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

        public List<decimal> GetDistinctDiscount(string connectionString)
        {
            //string result = string.Empty;
            List<decimal> lstDiscount = new List<decimal>();
            try{
                using (MySqlConnection conn = GetConnection(connectionString))  
                {  

                      
                    MySqlCommand cmd = new MySqlCommand(QueryStringClass.getDiscountDistinct, conn); 

                    //result = cmd.CommandText;

                    conn.Open();
                    cmd.Prepare();

                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())  
                    {  
                       decimal resDiscount =  dataReader["DISCOUNT"]  == DBNull.Value ? 0 : Convert.ToDecimal(dataReader["DISCOUNT"]);
                       if(resDiscount != 0)
                       {lstDiscount.Add(resDiscount);}
                    }  

                    conn.Close();

                }
                return lstDiscount;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine(ex.StackTrace+ex.Message);
                return lstDiscount;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace+ex.Message);
                return lstDiscount;
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