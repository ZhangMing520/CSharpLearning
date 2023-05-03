using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using MyBlog.WebApi._Filter;
using MyBlog.WebApi.Utility.ApiResult;

namespace MyBlog.WebApi.Controllers;

/// <summary>
/// 测试在方法上鉴权，而不是类上
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet("Authorize")]
    [Authorize]
    public string Authorize()
    {
        return "this is Authorize";
    }

    [HttpGet("NoAuthorize")]
    [Authorize]
    public string NoAuthorize()
    {
        return "this is NoAuthorize";
    }

    [TypeFilter(typeof(CustomResourceFilterAttribute))]
    [HttpGet("GetCache")]
    public IActionResult GetCache(string name)
    {
        return new JsonResult(new
        {
            name = name,
            age = 18,
            sex = true
        });
    }
    
}