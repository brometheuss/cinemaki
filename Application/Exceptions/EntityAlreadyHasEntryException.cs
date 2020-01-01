using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EntityAlreadyHasAnEntryException : Exception
    {
        public EntityAlreadyHasAnEntryException(string message) : base("Entity already has a " + message)
        {
        }
    }
}
