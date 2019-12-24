using Application.DataTransfer;
using Application.Interfaces;
using Application.Queries;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.WriterCommands
{
    public interface IGetWritersCommand : ICommand<WriterQuery, PagedResponse<WriterDto>>
    {
    }
}
