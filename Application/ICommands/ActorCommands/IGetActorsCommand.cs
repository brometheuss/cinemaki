using Application.DataTransfer;
using Application.Interfaces;
using Application.Queries;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.ActorCommands
{
    public interface IGetActorsCommand : ICommand<ActorQuery, PagedResponse<ActorDto>>
    {
    }
}
