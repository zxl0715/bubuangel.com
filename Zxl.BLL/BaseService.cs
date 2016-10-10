using Zxl.IBLL;
using Zxl.IDAL;
namespace Zxl.BLL
{
    public abstract class BaseService<T> : InterfacBaseService<T> where T : class
    {
        protected InterfaceBaseRepository<T> CurrentRepostitory { get; set; }

        public BaseService(InterfaceBaseRepository<T> currentRepostitory)
        {
            CurrentRepostitory = currentRepostitory;
        }

        public T Add(T entity)
        {
            return CurrentRepostitory.Add(entity);
        }

        public bool update(T entity)
        {
            return CurrentRepostitory.Update(entity);
        }

        public bool Delete(T entity)
        {
            return CurrentRepostitory.Delete(entity);
        }
    }
}
