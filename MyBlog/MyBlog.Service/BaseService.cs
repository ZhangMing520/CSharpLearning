using MyBlog.IRepository;
using MyBlog.IService;
using SqlSugar;
using System.Linq.Expressions;

namespace MyBlog.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        // 从子类构造方法中注入
        protected IBaseRepository<TEntity> _repository;

        public async Task<bool> CreateAsync(TEntity entity)
        {
            return await _repository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        // dto  -> 用户数据，不能把密码也返回前端
        public virtual async Task<bool> EditAsync(TEntity entity)
        {
            return await _repository.EditAsync(entity);
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func)
        {
            return await _repository.FindAsync(func);
        }

        public async Task<List<TEntity>> QueryAsync()
        {
            return await _repository.QueryAsync();
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
            return await _repository.QueryAsync(func);
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func, int page, int size,
            RefAsync<int> total)
        {
            return await _repository.QueryAsync(func, page, size, total);
        }

        public async Task<List<TEntity>> QueryAsync(int page, int size, RefAsync<int> total)
        {
            return await _repository.QueryAsync(page, size, total);
        }
    }
}