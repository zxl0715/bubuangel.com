﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zxl.IBLL
{
    /// <summary>
    /// 接口类
    /// </summary>
    public interface InterfacBaseService<T> where T:class
    {

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        T Add(T entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Update(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Delete(T entity);

    }
}
