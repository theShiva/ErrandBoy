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
            var dictionary = new Dictionary<string, HttpControllerDescriptor>(StringComparer.OrdinalIgnoreCase);

            var assembliesResolver = _httpConfiguration.Services.GetAssembliesResolver();
            var controllersResolver = _httpConfiguration.Services.GetHttpControllerTypeResolver();

            var controllerTypes = controllersResolver.GetControllerTypes(assembliesResolver);

            foreach (var controllerType in controllerTypes)
            {
                var segments = controllerType.Namespace.Split(Type.Delimiter);

                var controllerName =
                    controllerType.Name.Remove(controllerType.Name.Length -
                                               DefaultHttpControllerSelector.ControllerSuffix.Length);

                var controllerKey = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", segments[segments.Length - 1],
                    controllerName);

                if (!dictionary.ContainsKey(controllerKey))
                {
                    dictionary[controllerKey] = new HttpControllerDescriptor(_httpConfiguration, controllerType.Name, controllerType: controllerType);
                }
            }

            return dictionary;
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
