using System;
using System.Collections.Generic;
using System.Text;
using EfDataAccess;

namespace EfCommands.ReservationEfCommands
{
    public class EfTakenSeatsCommand : EfBaseCommand
    {
        public EfTakenSeatsCommand(EfCinemakContext context) : base(context)
        {
        }
    }
}
