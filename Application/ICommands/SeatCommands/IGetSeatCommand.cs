using Application.DataTransfer;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.SeatCommands
{
    public interface IGetSeatCommand : ICommand<int, SeatDto>
    {
    }
}
