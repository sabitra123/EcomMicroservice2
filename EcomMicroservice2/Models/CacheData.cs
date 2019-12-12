using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

public static class CacheFilter //: ActionFilterAttribute
{
    //public int TimeDuration { get; set; }
    //public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    //{
    //    actionExecutedContext.Response.Headers.CacheControl = new CacheControlHeaderValue
    //    {
    //        MaxAge = TimeSpan.FromSeconds(TimeDuration),
    //        MustRevalidate = true,
    //        Public = true
    //    };
    //}

    //Export Excel for Table List page
    private static Dictionary<string, List<object>> _ExportCache = new Dictionary<string, List<object>>();

    public static void AddCache(string ControlerFunctionName, List<object> lst)
    {
        List<object> _Value;
        _ExportCache.TryGetValue(ControlerFunctionName, out _Value);
        if (_Value == null)
        { _ExportCache.Add(ControlerFunctionName, _Value); }
        else if (_Value != null)
        { _ExportCache[ControlerFunctionName] = _Value; }
    }


    public static List<object> GetCache(string ControlerFunctionName)
    {
        List<object> _Value;
        _ExportCache.TryGetValue(ControlerFunctionName, out _Value);
        return _Value;
    }


    }