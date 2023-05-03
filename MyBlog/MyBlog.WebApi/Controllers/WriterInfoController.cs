using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using MyBlog.Model.DTO;
using MyBlog.WebApi.Utility._MD5;
using MyBlog.WebApi.Utility.ApiResult;

namespace MyBlog.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class WriterInfoController : ControllerBase
    {
        private readonly IWriterInfoService _writerInfoService;

        private readonly ILogger<WriterInfoController> _logger;

        public WriterInfoController(ILogger<WriterInfoController> logger, IWriterInfoService writerInfoService)
        {
            this._logger = logger;
            this._writerInfoService = writerInfoService;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<ApiResult>> Create(string name, string usernanme, string userpwd)
        {
            WriterInfo writerInfo = new WriterInfo
            {
                Name = name,
                UserName = usernanme,
                UserPwd = MD5Helper.MD5Encrypt32(userpwd)
            };
            WriterInfo oldWriter = await _writerInfoService.FindAsync(c => c.UserName == usernanme);
            if (oldWriter == null)
            {
                bool b = await _writerInfoService.CreateAsync(writerInfo);
                if (b)
                {
                    return ApiResultHelper.Success(writerInfo);
                }
                else
                {
                    return ApiResultHelper.Error("添加失败，服务器发生错误");
                }
            }
            else
            {
                return ApiResultHelper.Error("账号已存在");
            }
        }

        /// <summary>
        ///  修改当期用户的密码
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPut("Edit")]
        public async Task<ActionResult<ApiResult>> Edit(string name)
        {
            // JWT 中获取 Id 
            int id = Convert.ToInt32(this.User.FindFirst("Id").Value);
            WriterInfo writerInfo = await _writerInfoService.FindAsync(id);
            writerInfo.Name = name;
            bool b = await _writerInfoService.EditAsync(writerInfo);
            if (!b)
            {
                return ApiResultHelper.Error("修改失败，服务器发生错误");
            }
            else
            {
                return ApiResultHelper.Success("修改成功");
            }
        }

        /// <summary>
        ///
        /// [AllowAnonymous] 允许匿名访问
        /// 
        /// </summary>
        /// <param name="iMapper"> [FromServices] 从服务注入，如果仅仅是这个方法使用，没必要从构造方法注入</param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("FindWriter")]
        [AllowAnonymous]
        public async Task<ActionResult<ApiResult>> Edit([FromServices] IMapper iMapper, int id)
        {
            WriterInfo writerInfo = await _writerInfoService.FindAsync(id);
            WriterInfoDTO writerInfoDto = iMapper.Map<WriterInfoDTO>(writerInfo);
            return ApiResultHelper.Success(writerInfoDto);
        }
        
        
    }
}