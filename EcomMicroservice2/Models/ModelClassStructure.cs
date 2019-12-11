using System;

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

    public class ProductDistinctClass : IDisposable
    {
    public string SegmentName { get; set; }
    public string FamilyName { get; set; }
    public string ClassName { get; set; }

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