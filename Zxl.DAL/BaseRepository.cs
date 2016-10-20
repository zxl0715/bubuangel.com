using System;
using System.Linq;
using System.Linq.Expressions;
using Zxl.IDAL;
using System.Data.Entity;
namespace Zxl.DAL
{
    /// <summary>
    /// 仓储基类
    /// http://www.cnblogs.com/mzwhj/p/3547394.html
    /// </summary>
    public class BaseRepository<T> : InterfaceBaseRepository<T> where T : class
    {
        /// <summary>
        /// ContextFactory是一个简单工厂类，GetCurrentContext()是一个静态函数。利用简单工厂获取请求内的当前DbContext，也就是请求内的DbContext单例。先添加一个工厂类ContextFactory
        /// </summary>
        protected ZxlDbContext nContext = ContextFactory.GetCurrentContext();

        public T Add(T entity)
        {
            nContext.Entry<T>(entity).State = EntityState.Added;

            return nContext.SaveChanges() > 0 ? entity : null;
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return nContext.Set<T>().Count(predicate);
        }

        public bool Update(T entity)
        {
            nContext.Set<T>().Attach(entity);
            nContext.Entry<T>(entity).State = EntityState.Modified;
            return nContext.SaveChanges() > 0;
        }

        public bool Delete(T entity)
        {
            nContext.Set<T>().Attach(entity);
            nContext.Entry<T>(entity).State = EntityState.Deleted;
            return nContext.SaveChanges() > 0;
        }

        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            return nContext.Set<T>().Any(anyLambda);
        }

        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            T _entity = nContext.Set<T>().FirstOrDefault<T>(whereLambda);
            return _entity;
        }

        public IQueryable<T> FindList(Expression<Func<T, bool>> whereLambda, string orderName, bool isAsc)
        {
            var _list = nContext.Set<T>().Where<T>(whereLambda);

            _list = OrderBy(_list, orderName, isAsc);

            return _list;
        }

        public IQueryable<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLambda, string orderName, bool isAsc)
        {
            var _list = nContext.Set<T>().Where<T>(whereLambda);
            totalRecord = _list.Count();    
             
                _list = OrderBy(_list,orderName,isAsc).Skip<T>((pageIndex-1)*pageSize).Take<T>(pageSize);
            return _list;
        }


        private IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, bool isAsc)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source", "不能为空");
            }
            if (string.IsNullOrEmpty(propertyName))
            {
                return source;
            }

            var _parameter = Expression.Parameter(source.ElementType);
            var _property = Expression.Property(_parameter, propertyName);
            if (_property == null)
            {
                throw new ArgumentNullException("propertyName", "属性不存在");
            }
            var _lambda = Expression.Lambda(_property, _parameter);
            var _methodName = isAsc ? "OrderBy" : "OrderbyDescending";
            var _resultExpression = Expression.Call(typeof(Queryable), _methodName, new Type[] { source.ElementType, _property.Type }, source.Expression, Expression.Quote(_lambda));

            return source.Provider.CreateQuery<T>(_resultExpression);

        }
    }
}
