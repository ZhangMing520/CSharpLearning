using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using MyBlog.WebApi.Utility.ApiResult;

namespace MyBlog.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize]
    public class TypeInfoController : ControllerBase
    {
        private readonly ITypeInfoService _typeInfoService;

        private readonly ILogger<BlogNewsController> _logger;

        public TypeInfoController(ILogger<BlogNewsController> logger, ITypeInfoService typeInfoService)
        {
            this._logger = logger;
            this._typeInfoService = typeInfoService;
        }

        [HttpGet("Types")]
        public async Task<ActionResult<ApiResult>> GetTypes()
        {
            var data = await _typeInfoService.QueryAsync();
            if (data == null)
            {
                return ApiResultHelper.Error("没有更多的类型");
            }
            else
            {
                return ApiResultHelper.Success(data);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ApiResult>> Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return ApiResultHelper.Error("文章类型名不能为空");
            }
            else
            {
                TypeInfo typeInfo = new TypeInfo
                {
                    Name = name
                };
                bool b = await _typeInfoService.CreateAsync(typeInfo);
                if (b)
                {
                    return ApiResultHelper.Success(typeInfo);
                }
                else
                {
                    return ApiResultHelper.Error("添加失败，服务器发生错误");
                }
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<ApiResult>> Delete(int id)
        {
            bool b = await _typeInfoService.DeleteAsync(id);
            if (b)
            {
                return ApiResultHelper.Success(b);
            }
            else
            {
                return ApiResultHelper.Error("删除失败");
            }
        }

        [HttpPut("Edit")]
        public async Task<ActionResult<ApiResult>> Edit(int id, string name)
        {
            TypeInfo typeInfo = await _typeInfoService.FindAsync(id);
            if (typeInfo == null)
            {
                return ApiResultHelper.Error("没有找到文章类型");
            }
            else
            {
                typeInfo.Name = name;
                bool b = await _typeInfoService.EditAsync(typeInfo);
                if (b)
                {
                    return ApiResultHelper.Success(typeInfo);
                }
                else
                {
                    return ApiResultHelper.Error("修改失败，服务器发生错误");
                }
            }
        }
        
    }
}