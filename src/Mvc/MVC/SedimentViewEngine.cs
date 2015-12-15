using System;
using System.Web.Mvc;

namespace Sediment.Web.MVC
{
    public class SedimentViewEngine : BuildManagerViewEngine
    {
        public SedimentViewEngine()
            : this(null)
        {
        }

        public SedimentViewEngine(IViewPageActivator viewPageActivator)
            : base(viewPageActivator)
        {
            //AreaViewLocationFormats = new[]
            //{
            //    "~/Areas/{2}/Views/{1}/{0}.cshtml",
            //    "~/Areas/{2}/Views/Shared/{0}.cshtml"
            //};
            //AreaMasterLocationFormats = new[]
            //{
            //    "~/Areas/{2}/Views/{1}/{0}.cshtml",
            //    "~/Areas/{2}/Views/Shared/{0}.cshtml"
            //};
            //AreaPartialViewLocationFormats = new[]
            //{
            //    "~/Areas/{2}/Views/{1}/{0}.cshtml",
            //    "~/Areas/{2}/Views/Shared/{0}.cshtml"
            //};

            ViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };
            MasterLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };
            PartialViewLocationFormats = new[]
            {
                "~/Views/{1}/{0}.cshtml",
                "~/Views/Shared/{0}.cshtml"
            };

            FileExtensions = new[]
            {
                "cshtml"
            };
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            throw new NotImplementedException();
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            throw new NotImplementedException();
        }
    }
}