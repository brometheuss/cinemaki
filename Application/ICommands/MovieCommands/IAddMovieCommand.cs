using Application.DataTransfer;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.MovieCommands
{
    public interface IAddMovieCommand : ICommand<MovieDto>
    {
    }
}
