using MyBlog.IRepository;
using MyBlog.IService;
using MyBlog.Model;

namespace MyBlog.Service
{
    public class BlogNewsService : BaseService<BlogNews>, IBlogNewsService
    {
        public BlogNewsService(IBlogNewsRepository _repository)
        {
            base._repository = _repository;
        }
    }
}