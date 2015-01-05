using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using System.Web.Http.Tracing;
using ErrandBoy.Common.Logging;
using ErrandBoy.Web.Common;
using ErrandBoy.Web.Common.Routing;

namespace ErrandBoy.Web.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Registere custom Route constraint for API Versioning (via ApiVersionConstraint class) with ASP.NET Web API 
            // so that it gets applied to incoming requests. 
            var constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("apiVersionConstraint", typeof(ApiVersionConstraint));
            config.MapHttpAttributeRoutes(constraintResolver);

            // Replace default implementation of controller selector to use our custom controller selector
            config.Services.Replace(typeof (IHttpControllerSelector) , new NamespaceHttpControllerSelector(config));
            // config.EnableSystemDiagnosticsTracing(); // replacing this with our custom ITraceWriter
            config.Services.Replace(typeof(ITraceWriter),new SimpleTraceWriter(WebContainerManager.Get<ILogManager>()));
        }
    }
}
