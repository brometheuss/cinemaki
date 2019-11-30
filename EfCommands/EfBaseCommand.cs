using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands
{
    public class EfBaseCommand
    {
        protected EfCinemakContext Context { get; }

        public EfBaseCommand(EfCinemakContext context)
        {
            Context = context;
        }
    }
}
