1. ASP.NET Core 6.0读取配置文件

    - [跟着官网学ASP.NET Core 6.0之读取配置文件](https://www.51cto.com/article/700623.html)

2. SQL Server连接串

    - [connection-string-syntax?view=sql-server-ver16](https://learn.microsoft.com/zh-cn/sql/connect/ado-net/connection-string-syntax?view=sql-server-ver16)

    ```
    使用 Windows 身份验证连接到本地服务器上的 AdventureWorks 数据库
    
    "Persist Security Info=False;Integrated Security=true;  
        Initial Catalog=AdventureWorks;Server=MSSQL1;Encrypt=True;"  
    "Persist Security Info=False;Integrated Security=SSPI;  
        database=AdventureWorks;server=(local);Encrypt=True;"  
    "Persist Security Info=False;Trusted_Connection=True;  
        database=AdventureWorks;server=(local);Encrypt=True;"
    
    
    使用下列语法来指定用户名和密码（使用下列语法来指定用户名和密码）
    "Persist Security Info=False;User ID=*****;Password=*****;Initial Catalog=AdventureWorks;Server=MySqlServer;Encrypt=True;"
    ```

3. SQL Server安装步骤

    - [SQL Server2019详细安装步骤](https://blog.csdn.net/weixin_39447365/article/details/128416624)


4. SQL Server管理工具

    - [QL Server 管理工具下载](https://learn.microsoft.com/zh-cn/sql/ssms/download-sql-server-management-studio-ssms?redirectedfrom=MSDN&view=sql-server-ver16)


5. Visual Studio设置文件编码集

    - [editorconfig 官网](https://editorconfig.org/)
    - [visual studio EditorConfig 如何使用进行配置](https://learn.microsoft.com/en-us/visualstudio/ide/create-portable-custom-editor-options?view=vs-2019)
    - [How to config visual studio to use UTF-8 as the default encoding for all projects?](https://stackoverflow.com/questions/41335199/how-to-config-visual-studio-to-use-utf-8-as-the-default-encoding-for-all-project)
    - [Visual Studio 2019修改编码UTF-8，实测不是很好用，不如VS Code](https://www.jb51.net/article/182665.htm)

6. AutoMapper 安装（自动映射DTO）

- [automapper 官网](https://automapper.org/)
- [Nuget AutoMapper](https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection)

```xml

<PackageReference Include="AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.1"/>
```
