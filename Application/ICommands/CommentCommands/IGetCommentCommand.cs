﻿using Application.DataTransfer;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ICommands.CommentCommands
{
    public interface IGetCommentCommand : IQuery<int, CommentDto>
    {
    }
}
