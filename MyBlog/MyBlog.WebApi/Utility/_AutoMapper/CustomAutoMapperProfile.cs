using AutoMapper;
using MyBlog.Model;
using MyBlog.Model.DTO;

namespace MyBlog.WebApi.Utility._AutoMapper;

/// <summary>
/// AutoMapper 配置类
/// </summary>
public class CustomAutoMapperProfile : Profile
{
    public CustomAutoMapperProfile()
    {
        base.CreateMap<WriterInfo, WriterInfoDTO>();
        base.CreateMap<BlogNews, BlogNewsDTO>()
            .ForMember(dest => dest.TypeInfoName, 
                source => source.MapFrom(src => src.TypeInfo.Name))
            .ForMember(dest => dest.WriterInfoName, 
                source => source.MapFrom(src => src.WriterInfo.Name))
            ;
    }
}
