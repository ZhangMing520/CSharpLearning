1. 安装 JWT 授权包

- [System.IdentityModel.Tokens.Jwt](https://www.nuget.org/packages/System.IdentityModel.Tokens.Jwt)

```xml

<PackageReference Include="System.IdentityModel.Tokens.Jwt" Version="6.30.0"/>
```

2. JWT 授权

```c#
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
```

3. 安装 JWT 授权包

- [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer)

```xml

<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="5.0.3"/>
```
