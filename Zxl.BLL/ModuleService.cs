using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zxl.IBLL;
using Zxl.Models;
using Zxl.DAL;
namespace Zxl.BLL
{
    public class ModuleService : BaseService<Module>, InterfaceModuleService
    {
        public ModuleService() : base(RepositoryFactory.ModuleRepoitory) { }
        public IQueryable<Module> GetList()
        {
            return null;
        }
    }
}
