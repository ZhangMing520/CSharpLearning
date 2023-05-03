using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyBlog.IService;
using MyBlog.JWT.Utility._MD5;
using MyBlog.JWT.Utility.ApiResult;
using MyBlog.Model;
using MyBlog.Service;

namespace MyBlog.JWT.Controllers;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("[controller]")]
public class AuthorizeController : ControllerBase
{
    private readonly ILogger<AuthorizeController> _logger;
    private readonly IWriterInfoService _writerInfoService;

    public AuthorizeController(ILogger<AuthorizeController> logger, IWriterInfoService writerInfoService)
    {
        _logger = logger;
        _writerInfoService = writerInfoService;
    }

    [HttpPost("Login")]
    public async Task<ActionResult<ApiResult>> Login(string username, string userpwd)
    {
        string pwd = MD5Helper.MD5Encrypt32(userpwd);
        WriterInfo writerInfo = await _writerInfoService.FindAsync(w => w.UserName == username && w.UserPwd == pwd);
        if (writerInfo == null)
        {
            return ApiResultHelper.Error("账号或者密码错误");
        }
        else
        {
            // JWT 固定授权代码
            // Claim 相当于一个键值对
            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, writerInfo.Name),
                new Claim("Id", writerInfo.Id.ToString()),
                new Claim("UserName", writerInfo.UserName),
            };
            // 相当于秘钥，最少16位；必须和 WebApi，你鉴别的秘钥是一致的
            SymmetricSecurityKey key =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SDMC-CJAS1-SAD-DFSFA-SADHJVF-VF"));

            // issuer 代表颁发了 Token 的web应用程序， audience 是 token 的受理者
            JwtSecurityToken token = new JwtSecurityToken(
                // issuer 需要修改一致 MyBlog.JWT Properties -> launchSettings.json 文件中applicationUrl
                issuer: "http://localhost:6060",
                // audience 需要修改一致 MyBlog.WebApi（被授权程序） Properties -> launchSettings.json 文件中applicationUrl
                audience: "http://localhost:5000",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return ApiResultHelper.Success(jwtToken);
        }
    }
}