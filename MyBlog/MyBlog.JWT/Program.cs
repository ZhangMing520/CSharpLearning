// JWT 单独一个服务，获取token
// SqlSugar.IOC 配置和 WebApi 一致

using Microsoft.OpenApi.Models;
using MyBlog.IRepository;
using MyBlog.IService;
using MyBlog.Repository;
using MyBlog.Service;
using SqlSugar.IOC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyBlog.JWT", Version = "v1" }); });

#region SqlSugar.IOC add

builder.Services.AddSqlSugar(new IocConfig()
{
    // 从builder中获取
    ConnectionString = builder.Configuration["SqlConn"],
    DbType = IocDbType.SqlServer,
    IsAutoCloseConnection = true
});

builder.Services.AddScoped<IWriterInfoRepository, WriterInfoRepository>();
builder.Services.AddScoped<IWriterInfoService, WriterInfoService>();

#endregion SqlSugar.IOC add

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();