using Ninject.Modules;
using NLayerApp.BLL.Interface;
using NLayerApp.BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NLayerApp.WEB.Util
{
    public class CategoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryService>();
        }
    }
}