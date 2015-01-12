using System;

namespace ErrandBoy.Web.Common.Security
{
    public class UserSession : IWebUserSession
    {
        public string Firstname
        {
            get { throw new NotImplementedException(); }
        }

        public string Lastname
        {
            get { throw new NotImplementedException(); }
        }

        public string Username
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public string ApiVersionInUse
        {
            get { throw new NotImplementedException(); }
        }

        public Uri RequestUri
        {
            get { throw new NotImplementedException(); }
        }

        public string HttpRequestMethod
        {
            get { throw new NotImplementedException(); }
        }
    }
}
