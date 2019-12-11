using System;

namespace EcomMicroservice2.Models
{
    public static class QueryStringClass
    {
        public static string getDistinctProduct = "select DISTINCT SEGMENT_NAME,FAMILY_NAME,CLASS_NAME from XXIBM_PRODUCT_CATALOGUE ";
    }
}