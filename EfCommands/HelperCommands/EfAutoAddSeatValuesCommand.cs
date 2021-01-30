using Application.DataTransfer;
using Application.ICommands.IHelperCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCommands.HelperCommands
{
    public class EfAutoAddSeatValuesCommand : EfBaseCommand, IAutoAddSeatValuesCommand
    {
        public EfAutoAddSeatValuesCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => throw new NotImplementedException();

        public string Name => "Auto add values to Seat table using EntityFramework";

        public void Execute(int id)
        {
            //number of seats per row, each row has a different letter in alphabetical order(A, B, C, D....etc)

            for (int i = 1; i < 31; i++)
            {
                Context.Seats.Add(new Domain.Seat
                {
                    HallId = 5,
                    IsBroken = false,
                    Name = "H",
                    Number = i
                });
            }
            //foreach (var seat in Context.Seats)
            //{
            //    Context.Remove(seat);
            //}

            Context.SaveChanges();
        }
    }
}
