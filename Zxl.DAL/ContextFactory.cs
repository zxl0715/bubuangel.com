using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace Zxl.DAL
{
    /// <summary>
    /// 上下文简单工厂类
    /// </summary>
    public class ContextFactory
    {

        public static ZxlDbContext GetCurrentContext()
        {
            //MSDN中讲CallContext提供对每个逻辑执行线程都唯一的数据槽，而在WEB程序里，每一个请求恰巧就是一个逻辑线程所以可以使用CallContext来实现单个请求之内的DbContext单例。
            ZxlDbContext _nContext = CallContext.GetData("ZxlContext") as ZxlDbContext;
            if (_nContext == null)
            {
                _nContext = new ZxlDbContext();
                CallContext.SetData("ZxlContext", _nContext);
            }
            return _nContext;
        }
    }
}
