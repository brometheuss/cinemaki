using Application.DataTransfer;
using Application.Interfaces;
using Application.Queries;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.ProductionCommands
{
    public interface IGetProductionsCommand : IQuery<ProductionQuery, PagedResponse<ProductionDto>>
    {
    }
}
