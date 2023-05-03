using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace MyBlog.WebApi._Filter;

/// <summary>
/// 在请求方法之前执行，需要打断点调试
/// </summary>
public class CustomResourceFilterAttribute : Attribute, IResourceFilter
{
    private readonly IMemoryCache _cache;

    public CustomResourceFilterAttribute(IMemoryCache cache)
    {
        _cache = cache;
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        // api/test/GetCache
        string path = context.HttpContext.Request.Path;
        // ?name=name
        string route = context.HttpContext.Request.QueryString.Value;
        //  api/test/GetCache?name=name
        string key = path + route;
        if (_cache.TryGetValue(key, out object value))
        {
            // 有 Result 之后，不会再进 Controller 中方法 
            context.Result = value as IActionResult;
        }
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        // api/test/GetCache
        string path = context.HttpContext.Request.Path;
        // ?name=name
        string route = context.HttpContext.Request.QueryString.Value;
        //  api/test/GetCache?name=name
        string key = path + route;
        _cache.Set(key, context.Result);
    }
    
}