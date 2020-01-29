using Application.DataTransfer;
using Application.Interfaces;
using Application.Queries;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.HallCommands
{
    public interface IGetHallsCommand : ICommand<HallQuery, PagedResponse<HallDto>>
    {
    }
}
