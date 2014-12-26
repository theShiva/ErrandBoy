using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace ErrandBoy.Web.Common
{
    public class NamespaceHttpControllerSelector : IHttpControllerSelector
    {
        public IDictionary<string, HttpControllerDescriptor> GetControllerMapping()
        {
            throw new NotImplementedException();
        }

        public HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            throw new NotImplementedException();
        }
    }
}
