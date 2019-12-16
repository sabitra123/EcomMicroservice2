using System;

namespace EcomMicroservice2.Models
{
    public static class QueryStringClass
    {
        public static string getDistinctSegmentProduct = "select DISTINCT SEGMENT, SEGMENT_NAME from XXIBM_PRODUCT_CATALOGUE  ORDER BY SEGMENT";
        public static string getDistinctFamilyProduct = "select DISTINCT FAMILY, FAMILY_NAME from XXIBM_PRODUCT_CATALOGUE WHERE SEGMENT=@SEGMENT ORDER BY FAMILY";
        public static string getDistinctClassProduct = "select DISTINCT CLASS, CLASS_NAME from XXIBM_PRODUCT_CATALOGUE WHERE FAMILY=@FAMILY  ORDER BY CLASS";
        public static string getDistinctCommodityProduct = "select DISTINCT COMMODITY, COMMODITY_NAME from XXIBM_PRODUCT_CATALOGUE WHERE CLASS=@CLASS  ORDER BY COMMODITY";
        public static string getDistinctBrandProduct = "select DISTINCT BRAND from XXIBM_PRODUCT_STYLE  ORDER BY BRAND";

        public static string getAllProductWithDetails = " Select FAMILY_NAME, CLASS_NAME, COMMODITY, COMMODITY_NAME,SKU.ITEM_NUMBER, SKU.DESCRIPTION,SKU.LONG_DESCRIPTION,BRAND,SKUAtt_Value1 AS SIZE, SKUAtt_Value2 AS COLOUR, LIST_PRICE,DISCOUNT,INSTOCK,PRICE_EFFECTIVE_DATE " +
                                                        " FROM XXIBM_PRODUCT_CATALOGUE AS CATALOGUE " +
                                                        " INNER JOIN XXIBM_PRODUCT_SKU AS SKU ON CATALOGUE.COMMODITY = SKU.CATALOGUE_CATEGORY " +
                                                        " INNER JOIN XXIBM_PRODUCT_STYLE AS STYLE ON STYLE.CATALOGUE_CATEGORY = SKU.CATALOGUE_CATEGORY "+
                                                        " INNER JOIN XXIBM_PRODUCT_PRICING AS PRICING ON PRICING.ITEM_NUMBER = SKU.ITEM_NUMBER "+
                                                        " WHERE 1=1 ";

        public static string getAllMenuDetails = " Select DISTINCT FAMILY, FAMILY_NAME ,  CLASS, CLASS_NAME from  XXIBM_PRODUCT_CATALOGUE  WHERE SEGMENT=@SEGMENT   ORDER BY FAMILY , FAMILY_NAME";

    }
}