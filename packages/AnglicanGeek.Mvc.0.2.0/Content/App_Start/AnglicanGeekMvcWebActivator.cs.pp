using System;

[assembly: WebActivator.PreApplicationStartMethod(typeof($rootnamespace$.App_Start.AnglicanGeekMvcWebActivator), "PreApplicationStart")]

namespace $rootnamespace$.App_Start
{
    public static class AnglicanGeekMvcWebActivator
    {
        public static void PreApplicationStart() 
        {
            // Comment or delete the parts of AnglicanGeek.Mvc you don't want to use, below.
            
            AnglicanGeek.Mvc.Configurator.UseRouteRegistrars();
            AnglicanGeek.Mvc.Configurator.UseSimpleDependencyContainer();
            AnglicanGeek.Mvc.Configurator.UseScopedFilters();
            AnglicanGeek.Mvc.Configurator.FixUpViewEngines();
        }
    }
}