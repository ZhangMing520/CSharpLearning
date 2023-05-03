using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.IService;
using MyBlog.Model;
using MyBlog.Model.DTO;
using MyBlog.WebApi.Utility.ApiResult;
using SqlSugar;

namespace MyBlog.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
// [Authorize]
public class BlogNewsController : ControllerBase
{
    private readonly IBlogNewsService _blogNewsService;

    private readonly ILogger<BlogNewsController> _logger;

    public BlogNewsController(ILogger<BlogNewsController> logger, IBlogNewsService blogNewsService)
    {
        this._logger = logger;
        this._blogNewsService = blogNewsService;
    }

    [HttpGet("BlogNews")]
    public async Task<ActionResult<ApiResult>> GetBlogNews()
    {
        var data = await _blogNewsService.QueryAsync();
        if (data == null)
        {
            return ApiResultHelper.Error("没有更多的文章");
        }
        else
        {
            return ApiResultHelper.Success(data);
        }
    }

    [HttpPost("Create")]
    public async Task<ActionResult<ApiResult>> Create(string title, string content, int typeId)
    {
        BlogNews blogNews = new BlogNews
        {
            Title = title,
            Content = content,
            Time = DateTime.Now,
            BrowseCount = 0,
            LikeCount = 0,
            TypeId = typeId,
            // 登录用户Id
            WriterId = Convert.ToInt32(this.User.FindFirst("Id").Value)
        };
        bool b = await _blogNewsService.CreateAsync(blogNews);
        if (b)
        {
            return ApiResultHelper.Success(blogNews);
        }
        else
        {
            return ApiResultHelper.Error("添加失败，服务器发生错误");
        }
    }

    [HttpDelete("Delete")]
    public async Task<ActionResult<ApiResult>> Delete(int id)
    {
        bool b = await _blogNewsService.DeleteAsync(id);
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
    public async Task<ActionResult<ApiResult>> Edit(int id, string title, string content, int typeId)
    {
        BlogNews blogNews = await _blogNewsService.FindAsync(id);
        if (blogNews == null)
        {
            return ApiResultHelper.Error("没有找到这篇文章");
        }
        else
        {
            blogNews.Title = title;
            blogNews.Content = content;
            blogNews.TypeId = typeId;
            bool b = await _blogNewsService.EditAsync(blogNews);
            if (b)
            {
                return ApiResultHelper.Success(blogNews);
            }
            else
            {
                return ApiResultHelper.Error("修改失败，服务器发生错误");
            }
        }
    }

    [HttpGet("BlogNewsPage")]
    public async Task<ActionResult<ApiResult>> GetBlogNewsPage([FromServices] IMapper iMapper, int page, int size)
    {
        RefAsync<int> total = 0;
        List<BlogNews> blogNewsList = await _blogNewsService.QueryAsync(page, size, total);
        try
        {
            List<BlogNewsDTO> blogNewsDTOList = iMapper.Map<List<BlogNewsDTO>>(blogNewsList);
            return ApiResultHelper.Success(blogNewsDTOList, total);
        }
        catch (Exception)
        {
            return ApiResultHelper.Error("AutoMapper映射错误");
        }
    }
        
}