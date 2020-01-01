using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.MovieCommands
{
    public interface IDeleteMovieCommand : ICommand<int>
    {
    }
}
