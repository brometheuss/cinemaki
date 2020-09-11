using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ICommand<TRequest>
    {
        void Execute(TRequest request);
    }
    public interface IQuery<TRequest, TResponse>
    {
        TResponse Execute(TRequest request);
    }
}
