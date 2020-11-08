using Application.DataTransfer;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.LogCommands
{
    public interface IGetLogCommand : IQuery<int, LogDto>
    {
    }
}
