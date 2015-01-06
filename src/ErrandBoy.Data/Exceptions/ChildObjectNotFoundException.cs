using System;

namespace ErrandBoy.Data.Exceptions
{
    public class ChildObjectNotFoundException : Exception
    {
        public ChildObjectNotFoundException(string message) : base(message)
        {
        }
    }
}
