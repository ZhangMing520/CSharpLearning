using MyBlog.IRepository;
using MyBlog.IService;
using MyBlog.Model;

namespace MyBlog.Service
{
    public class TypeInfoService : BaseService<TypeInfo>, ITypeInfoService
    {
        public TypeInfoService(ITypeInfoRepository _repository)
        {
            base._repository = _repository;
        }
    }
}