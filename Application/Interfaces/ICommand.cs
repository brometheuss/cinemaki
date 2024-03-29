﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }
    public interface IQuery<TRequest, TResponse> : IUseCase
    {
        TResponse Execute(TRequest request);
    }

    public interface IUseCase
    {
        int Id { get; }
        string Name { get; }
    }
}
