using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class EntityMustHaveConfirmedPassword : Exception
    {
        public EntityMustHaveConfirmedPassword(string message) : base(message)
        {
        }
    }
}
