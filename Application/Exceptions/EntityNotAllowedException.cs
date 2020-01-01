using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EntityNotAllowedException : Exception
    {
        public EntityNotAllowedException(string message) : base(message + " is not allowed.")
        {
        }
    }
}
