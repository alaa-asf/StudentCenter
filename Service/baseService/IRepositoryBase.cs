using StudentCenter.Entities;
using System.Linq.Expressions;

namespace StudentCenter.Service.baseService
{

    public interface IRepositoryBase<T> where T : class
    {
        Task<IQueryable<T>> FindAll(bool trackChanges);
        Task<IQueryable<T>> List();
        Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

        Task<T> FindByID(long ID);

        Task<Operation_Result> Add(T entity);
        Task<Operation_Result> Update(long ID, T entity);

        Task<Operation_Result> Delete(long ID);



    }
}
