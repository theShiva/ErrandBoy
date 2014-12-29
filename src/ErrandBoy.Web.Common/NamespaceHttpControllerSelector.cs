using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Routing;
using NHibernate.Util;

namespace ErrandBoy.Web.Common
{
    public class NamespaceHttpControllerSelector : IHttpControllerSelector
    {
        private readonly HttpConfiguration _httpConfiguration;
        private readonly Lazy<Dictionary<string, HttpControllerDescriptor>> _controllers;

        public NamespaceHttpControllerSelector(HttpConfiguration configuration)
        {
            _httpConfiguration = configuration;
            _controllers = new Lazy<Dictionary<string, HttpControllerDescriptor>>(InitializeControllerDictionary);
        }

        private Dictionary<string, HttpControllerDescriptor> InitializeControllerDictionary()
        {
            throw new NotImplementedException();
        }
        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            return _controllers.Value;
        }

        public HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            throw new NotImplementedException();
        }

        private string GetControllerName(IHttpRouteData httpRouteData)
        {
            var httpSubRoute = httpRouteData.GetSubRoutes().FirstOrDefault();
            if (httpRouteData == null) return null;

            var dataTokenValue = httpSubRoute.Route.DataTokens.First().Value;
            if (dataTokenValue == null) return null;

            var controllerName =
                ((HttpActionDescriptor[]) dataTokenValue).First()
                    .ControllerDescriptor.ControllerName.Replace("Controller", string.Empty);

            return controllerName;
        }

        private T GetRouteVariable<T>(IHttpRouteData httpRouteData, string name)
        {
            object result;
            if (httpRouteData.Values.TryGetValue(name, out result)) ;
            {
                return (T)result;
            }
            return default(T);
        }

        private string GetVersion(IHttpRouteData httpRouteData)
        {
            var httpSubRouteData = httpRouteData.GetSubRoutes().FirstOrDefault();
            if (httpSubRouteData == null) return null;
            return GetRouteVariable<string>(httpSubRouteData, "apiVersion");
        }

    }
}
