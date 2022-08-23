using Microsoft.EntityFrameworkCore;
using StudentCenter.Entities;
using System.Linq.Expressions;

namespace StudentCenter.Service.baseService
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected StudentCenterContext _context;
        
        public RepositoryBase(StudentCenterContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<T>> List() => _context.Set<T>().AsNoTracking();







        public async Task<IQueryable<T>> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ?
              _context.Set<T>()
                .Where(expression)
                .AsNoTracking() :
              _context.Set<T>()
                .Where(expression);

        public async Task<T> FindByID(long ID)
        {
            try
            {
                T Obj = await _context.Set<T>().FindAsync(ID);
                if (Obj != null)
                    return Obj;
            }
            catch (Exception ex)
            {
                return null;
            }

            return null;
        }




        public async Task<IQueryable<T>> FindAll(bool trackChanges)
        {
            return !trackChanges ?
               _context.Set<T>().AsNoTracking() : _context.Set<T>();
        }






        public async Task<Operation_Result> Add(T entity)
        {
            try
            {

                _context.Set<T>().Add(entity);
                await _context.SaveChangesAsync();
                return new Operation_Result { SUCCESS = true, Result = entity }; ;

            }
            catch (Exception ex)
            {
                return new Operation_Result { SUCCESS = false, ERROR = ex.Message };
            }
            return new Operation_Result { SUCCESS = false, ERROR = "" };

        }

        public async Task<Operation_Result> Update(long ID, T entity)
        {
            try
            {

                _context.Set<T>().Update(entity);
                await _context.SaveChangesAsync();
                return new Operation_Result { SUCCESS = true, Result = entity }; ;

            }
            catch (Exception ex)
            {
                return new Operation_Result { SUCCESS = false, ERROR = ex.Message };
            }

            return new Operation_Result { SUCCESS = false, ERROR = "" };

        }


        public async Task<Operation_Result> Delete(long ID)
        {
            try
            {
                var Object = _context.Set<T>().FindAsync(ID);
                if (Object != null)
                {
                    _context.Set<T>().Remove(Object as T);
                    _context.SaveChangesAsync();
                    return new Operation_Result { SUCCESS = true, };
                }
            }
            catch (Exception ex)
            {
                return new Operation_Result { SUCCESS = false, ERROR = ex.Message };
            }

            return new Operation_Result { SUCCESS = false, ERROR = "" };
        }


        public async Task<Operation_Result> Delete(T entity)
        {
            try
            {
                if (entity != null)
                {
                    _context.Set<T>().Remove(entity);
                    _context.SaveChangesAsync();
                    return new Operation_Result { SUCCESS = true, }; ;
                }
            }
            catch (Exception ex)
            {
                return new Operation_Result { SUCCESS = false, ERROR = ex.Message };
            }

            return new Operation_Result { SUCCESS = false, ERROR = "" };
        }

    }
}
