using System;
using System.Web.Http.Filters;
using NHibernate;

namespace ErrandBoy.Web.Common
{
    public class ActionTransactionHelper : IActionTransactionHelper
    {
        private readonly ISessionFactory _sessionFactory;

        public ActionTransactionHelper(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void EndTransaction(HttpActionExecutedContext filterContext)
        {
            throw new NotImplementedException();
        }

        public void CloseSession()
        {
            throw new NotImplementedException();
        }
    }
}
