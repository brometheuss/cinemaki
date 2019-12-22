using Application.DataTransfer;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.ProductionCommands
{
    public interface IGetProductionCommand : ICommand<int, ProductionDto>
    {
    }
}
