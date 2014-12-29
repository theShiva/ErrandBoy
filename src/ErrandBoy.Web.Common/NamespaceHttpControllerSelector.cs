using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
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

        public HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var routeData = request.GetRouteData();
            if (routeData == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var controllerName = GetControllerName(routeData);
            if (controllerName == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var namespaceName = GetVersion(routeData);
            if (namespaceName == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var controllerKey = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", namespaceName, controllerName);

            HttpControllerDescriptor controllerDescriptor;
            if (_controllers.Value.TryGetValue(controllerKey, out controllerDescriptor))
            {
                return controllerDescriptor;
            }

            throw new HttpResponseException(HttpStatusCode.NotFound);

        }

        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            return _controllers.Value;
        }

        private Dictionary<string, HttpControllerDescriptor> InitializeControllerDictionary()
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
