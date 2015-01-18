using System.Linq;
using ErrandBoy.Common;
using ErrandBoy.Common.Security;
using ErrandBoy.Data.Entities;
using ErrandBoy.Data.Exceptions;
using ErrandBoy.Data.QueryProcessors;
using NHibernate;
using Task = ErrandBoy.Data.Entities.Task;

namespace ErrandBoy.Data.SqlServer.QueryProcessors
{
    public class AddTaskQueryProcessor : IAddTaskQueryProcessor
    {
        private readonly IDateTime _dateTime;
        private readonly ISession _session;
        private readonly IUserSession _userSession;

        public AddTaskQueryProcessor(ISession session, IUserSession userSession, IDateTime dateTime)
        {
            _session = session;
            _userSession = userSession;
            _dateTime = dateTime;
        }

        public void AddTask(Task task)
        {
            task.CreatedOnDate = _dateTime.UtcNow;
            task.CurrentStatus = _session.QueryOver<Status>().Where(
                x => x.Name == "Not Started").SingleOrDefault();
            task.CreatedBy = _session.QueryOver<User>().Where(
                x => x.UserName == _userSession.Username).SingleOrDefault();

            if (task.Users != null && task.Users.Any())
            {
                for (var i = 0; i < task.Users.Count; ++i)
                {
                    var user = task.Users[i];
                    var persistedUser = _session.Get<User>(user.UserId);
                    if (persistedUser == null)
                    {
                        throw new ChildObjectNotFoundException("User not found");
                    }
                    task.Users[i] = persistedUser;
                }
            }

            _session.SaveOrUpdate(task);
        }
    }
}
