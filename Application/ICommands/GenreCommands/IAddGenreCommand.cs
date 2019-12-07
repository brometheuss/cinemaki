﻿using Application.DataTransfer;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.GenreCommands
{
    public interface IAddGenreCommand : ICommand<GenreDto>
    {
    }
}
