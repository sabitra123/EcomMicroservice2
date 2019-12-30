using System;
using System.Collections.Generic;

namespace EcomMicroservice2.Models
{
    public class ProductClass : IDisposable
    {
    public Int32 Segment { get; set; }
    public string SegmentName { get; set; }
    public Int32 Family { get; set; }
    public string FamilyName { get; set; }
    public Int32 Class { get; set; }
    public string ClassName { get; set; }
    public Int32 Commodity { get; set; }
    public string CommodityName { get; set; }

    bool disposed = false;
    // Public implementation of Dispose pattern callable by consumers.
   public void Dispose()
   { 
      Dispose(true);
      GC.SuppressFinalize(this);           
   }

    protected virtual void Dispose(bool disposing)
    {
            if (disposed)
                return; 
            
            if (disposing) {
                // Free any other managed objects here.
                //
            }          
            disposed = true;
    }
   
   // Protected implementation of Dispose pattern.
    }

    public class ProductSegmentClass : IDisposable
    {
    public string SegmentName { get; set; }
    public Int32 Segment { get; set; }
    
    bool disposed = false;
    // Public implementation of Dispose pattern callable by consumers.
   public void Dispose()
   { 
      Dispose(true);
      GC.SuppressFinalize(this);           
   }

    protected virtual void Dispose(bool disposing)
    {
            if (disposed)
                return; 
            
            if (disposing) {
                // Free any other managed objects here.
                //
            }          
            disposed = true;
    }
   
   // Protected implementation of Dispose pattern.
    }

    // ITEM_NO,DESCRIPTION, LONG_DESCRIPTION, CATALOGUE_CATEGORY,BRAND

    public class ProductBrandClass
    {
       // public Int32 ITEM_NO { get; set; }
       // public string DESCRIPTION { get; set; }
      //  public string LONG_DESCRIPTION { get; set; }
      //  public Int32 CATALOGUE_CATEGORY { get; set; }
        public string BRAND { get; set; }
    }

        public class ProductColorClass
    {
       // public Int32 ITEM_NO { get; set; }
       // public string DESCRIPTION { get; set; }
      //  public string LONG_DESCRIPTION { get; set; }
      //  public Int32 CATALOGUE_CATEGORY { get; set; }
        public string COLOUR { get; set; }
    }

        public class ProductSizeClass
    {
       // public Int32 ITEM_NO { get; set; }
       // public string DESCRIPTION { get; set; }
      //  public string LONG_DESCRIPTION { get; set; }
      //  public Int32 CATALOGUE_CATEGORY { get; set; }
        public string SIZE { get; set; }
    }

    // CLASS, CLASS_NAME

    public class ProductClassClass
    {
        public Int32 CLASS { get; set; }
        public string CLASS_NAME { get; set; }
    }

    // FAMILY, FAMILY_NAME

    
    public class ProductFamilyClass
    {
        public Int32 FAMILY { get; set; }
        public string FAMILY_NAME { get; set; }
    }

// COMMODITY, COMMODITY_NAME

    public class ProductcommodityClass
    {
        public Int32 COMMODITY { get; set; }
        public string COMMODITY_NAME { get; set; }
    }

    public class ProductMenuDetails
    {
        public Int32 FAMILY { get; set; }
        public string FAMILY_NAME {get; set;}
        public List<ProductClassClass> lst {get; set;}

    }

    // COMMODITY, COMMODITY_NAME,SKU.ITEM_NUMBER, SKU.DESCRIPTION,SKU.LONG_DESCRIPTION,BRAND,SKUAtt_Value1 AS SIZE, SKUAtt_Value2 AS COLOUR, LIST_PRICE,DISCOUNT,INSTOCK,PRICE_EFFECTIVE_DATE
    public class ProductDetailsClass
    {

    public string FAMILY_NAME {get; set;}
    public string CLASS_NAME { get; set; }
    public Int32? COMMODITY { get; set; }
    public string COMMODITY_NAME { get; set; }
    public Int32? ITEM_NUMBER { get; set; }
    public string DESCRIPTION { get; set; } 
    public string LONG_DESCRIPTION { get; set; }
    public string BRAND { get; set; }
    public string SIZE { get; set; }
    public string COLOUR { get; set; }
    public decimal? LIST_PRICE { get; set; }
    public decimal? DISCOUNT { get; set; }
    public string INSTOCK { get; set; }
    public DateTime? PRICE_EFFECTIVE_DATE { get; set; }
    }


    public class ProductItemSKUClass
    {
    public Int32 ItemNumber { get; set; }
    public string Description { get; set; }
    public string LongDescription { get; set; }
    public Int32 CalelogueCategory { get; set; }
    public string SKUUnitofMeasure { get; set; }
    public Int32 StyleItem { get; set; }
    public string SKUAttr1 { get; set; }

    public string SKUAttr2 { get; set; }
    public string SKUAttr3 { get; set; }
    public string SKUAttr4 { get; set; }
    public string SKUAttr5 { get; set; }
    public string SKUAttr6 { get; set; }

    public string SKUAttrValue1 { get; set; }
    public string SKUAttrValue2 { get; set; }
    public string SKUAttrValue3 { get; set; }
    public string SKUAttrValue4 { get; set; }
    public string SKUAttrValue5 { get; set; }
    public string SKUAttrValue6 { get; set; }
    }

    
    public class ProductStyleClass
    {
    public Int32 ItemNumber { get; set; }
    public string Description { get; set; }
    public string LongDescription { get; set; }
    public Int32 CatalogueCategory { get; set; }
    public string Brand { get; set; }

    }

    public class ProductPricingClass
    {
    public Int32 PriceID { get; set; }
    public Int32 ItemNumber { get; set; }
    public decimal ListPrice { get; set; }
    public decimal Discount { get; set; }
    public string InStock { get; set; }
    public DateTime PriceEffectiveDate { get; set; }

    }



}