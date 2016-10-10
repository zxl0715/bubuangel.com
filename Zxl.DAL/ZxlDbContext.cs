﻿using Zxl.Models;
using System.Data.Entity;


namespace Zxl.DAL
{
    /// <summary>
    /// 数据上下文
    /// http://www.cnblogs.com/mzwhj/p/3547394.html
    /// </summary>
    public class ZxlDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserGroup> UserGroups { get; set; }

        public DbSet<UserConfig> UserConifg { get; set; }

        public ZxlDbContext()
            : base("DefaultConnection")
        { }
    }
}