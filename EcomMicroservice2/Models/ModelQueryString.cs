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
        public static string getDistinctSizeProduct = "select DISTINCT  SKU_ATTRIBUTE_VALUE1  AS SIZE from XXIBM_PRODUCT_SKU  ORDER BY SKU_ATTRIBUTE_VALUE1";
        public static string getDistinctColorProduct = "select DISTINCT  SKU_ATTRIBUTE_VALUE2  AS COLOUR from XXIBM_PRODUCT_SKU  ORDER BY SKU_ATTRIBUTE_VALUE2";


        public static string getAllProductWithDetails = " Select FAMILY_NAME, CLASS_NAME, COMMODITY, COMMODITY_NAME,SKU.ITEM_NUMBER, SKU.DESCRIPTION,SKU.LONG_DESCRIPTION,BRAND,SKU_ATTRIBUTE_VALUE1  AS SIZE, SKU_ATTRIBUTE_VALUE2  AS COLOUR, LIST_PRICE,DISCOUNT,IN_STOCK,PRICE_EFFECTIVE_DATE " +
                                                        " FROM XXIBM_PRODUCT_CATALOGUE AS CATALOGUE " +
                                                        " LEFT JOIN XXIBM_PRODUCT_SKU AS SKU ON CATALOGUE.COMMODITY = SKU.CATALOGUE_CATEGORY " +
                                                        " LEFT JOIN XXIBM_PRODUCT_STYLE AS STYLE ON CATALOGUE.COMMODITY = STYLE.CATALOGUE_CATEGORY "+
                                                        " RIGHT JOIN XXIBM_PRODUCT_PRICING AS PRICING ON SKU.ITEM_NUMBER = PRICING.ITEM_NUMBER   "+
                                                        " WHERE 1=1" ;

        public static string getAllProductWithDetailsNoFilter = " Select FAMILY_NAME, CLASS_NAME, COMMODITY, COMMODITY_NAME,SKU.ITEM_NUMBER, SKU.DESCRIPTION,SKU.LONG_DESCRIPTION,BRAND,SKU_ATTRIBUTE_VALUE1  AS SIZE, SKU_ATTRIBUTE_VALUE2  AS COLOUR, LIST_PRICE, DISCOUNT, IN_STOCK, PRICE_EFFECTIVE_DATE " +
                                                        " FROM XXIBM_PRODUCT_CATALOGUE AS CATALOGUE " +
                                                        " LEFT JOIN XXIBM_PRODUCT_SKU AS SKU ON CATALOGUE.COMMODITY = SKU.CATALOGUE_CATEGORY " +
                                                        " LEFT JOIN XXIBM_PRODUCT_STYLE AS STYLE ON CATALOGUE.COMMODITY = STYLE.CATALOGUE_CATEGORY "+
                                                        " LEFT JOIN XXIBM_PRODUCT_PRICING AS PRICING ON SKU.ITEM_NUMBER = PRICING.ITEM_NUMBER   ";

        public static string getSearchProductWithDetails = " Select FAMILY_NAME, CLASS_NAME, COMMODITY, COMMODITY_NAME,SKU.ITEM_NUMBER, SKU.DESCRIPTION,SKU.LONG_DESCRIPTION,BRAND,SKU_ATTRIBUTE_VALUE1  AS SIZE, SKU_ATTRIBUTE_VALUE2  AS COLOUR, LIST_PRICE,DISCOUNT,IN_STOCK,PRICE_EFFECTIVE_DATE " +
                                                        " FROM XXIBM_PRODUCT_CATALOGUE AS CATALOGUE " +
                                                        " INNER JOIN XXIBM_PRODUCT_SKU AS SKU ON CATALOGUE.COMMODITY = SKU.CATALOGUE_CATEGORY " +
                                                        " INNER JOIN XXIBM_PRODUCT_STYLE AS STYLE ON STYLE.CATALOGUE_CATEGORY = SKU.CATALOGUE_CATEGORY "+
                                                        " INNER JOIN XXIBM_PRODUCT_PRICING AS PRICING ON PRICING.ITEM_NUMBER = SKU.ITEM_NUMBER "+
                                                        " WHERE CATALOGUE.FAMILY_NAME LIKE @SEARCHVALUE OR CATALOGUE.CLASS_NAME LIKE @SEARCHVALUE  OR  CATALOGUE.COMMODITY_NAME LIKE @SEARCHVALUE "+
                                                        " OR  SKU.DESCRIPTION LIKE @SEARCHVALUE OR BRAND LIKE @SEARCHVALUE  OR SKU_ATTRIBUTE_VALUE2 LIKE @SEARCHVALUE ";
        public static string getAllMenuDetails = " Select DISTINCT FAMILY, FAMILY_NAME ,  CLASS, CLASS_NAME from  XXIBM_PRODUCT_CATALOGUE  WHERE SEGMENT=@SEGMENT   ORDER BY FAMILY , FAMILY_NAME";

    }
}