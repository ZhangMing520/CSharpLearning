using System.Linq.Expressions;
using MyBlog.Model;
using MyBlog.IRepository;
using SqlSugar;

namespace MyBlog.Repository
{
    /// <summary>
    /// 
    /// IBlogNewsRepository 定义了需要实现的接口
    /// IBlogNewsRepository 定义了需要实现的接口
    /// BaseRepository 实现了 IBlogNewsRepository 中通用接口部分
    /// 所以需要继承BaseRepository 和实现IBlogNewsRepository
    /// 
    /// </summary>
    public class BlogNewsRepository : BaseRepository<BlogNews>, IBlogNewsRepository
    {
        /// <summary>
        /// 导航查询，表中有外键的情况，查询实体中的外键实体
        /// </summary>
        /// <returns></returns>
        public async override Task<List<BlogNews>> QueryAsync()
        {
            return await base.Context.Queryable<BlogNews>()
                .Mapper(c => c.TypeInfo, c => c.TypeId, c => c.TypeInfo.Id)
                .Mapper(c => c.WriterInfo, c => c.WriterId, c => c.WriterInfo.Id)
                .ToListAsync();
        }

        public override Task<List<BlogNews>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return base.Context.Queryable<BlogNews>()
                .Mapper(c => c.TypeInfo, c => c.TypeId, c => c.TypeInfo.Id)
                .Mapper(c => c.WriterInfo, c => c.WriterId, c => c.WriterInfo.Id)
                .ToPageListAsync(page, size, total);
        }

        public override Task<List<BlogNews>> QueryAsync(Expression<Func<BlogNews, bool>> func, int page, int size,
            RefAsync<int> total)
        {
            return base.Context.Queryable<BlogNews>()
                .Where(func)
                .Mapper(c => c.TypeInfo, c => c.TypeId, c => c.TypeInfo.Id)
                .Mapper(c => c.WriterInfo, c => c.WriterId, c => c.WriterInfo.Id)
                .ToPageListAsync(page, size, total);
        }
    }
}