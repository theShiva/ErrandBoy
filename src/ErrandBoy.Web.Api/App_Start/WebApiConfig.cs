using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using ErrandBoy.Web.Common;
using ErrandBoy.Web.Common.Routing;

namespace ErrandBoy.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //
            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));
            config.MapHttpAttributeRoutes(constraintResolver);

            config.Services.Replace(typeof (IHttpControllerSelector) , new NamespaceHttpControllerSelector(config));
        }
    }
}
