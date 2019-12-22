using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EntityCannotBeNullException : Exception
    {
        public EntityCannotBeNullException(string message) : base(message + " cannot be blank. Please try again.")
        {
        }
    }
}
