using MyBlog.IRepository;
using MyBlog.IService;
using MyBlog.Model;

namespace MyBlog.Service
{
    public class WriterInfoService : BaseService<WriterInfo>, IWriterInfoService
    {
        public WriterInfoService(IWriterInfoRepository _repository)
        {
            base._repository = _repository;
        }
    }
}