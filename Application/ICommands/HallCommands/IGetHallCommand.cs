﻿using Application.DataTransfer;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.HallCommands
{
    public interface IGetHallCommand : IQuery<int, HallDto>
    {
    }
}
