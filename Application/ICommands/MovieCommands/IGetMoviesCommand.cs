using Application.DataTransfer;
using Application.Interfaces;
using Application.Queries;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.MovieCommands
{
    public interface IGetMoviesCommand : IQuery<MovieQuery, PagedResponse<MovieDto>>
    {
    }
}
