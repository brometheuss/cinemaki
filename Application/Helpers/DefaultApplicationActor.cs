using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Helpers
{
    public class DefaultApplicationActor : IApplicationActor
    {
        public int Id => 0;

        public string Identity => "Guest";

        public IEnumerable<int> AllowedUseCases => new List<int> { 10, 34, 35, 39, 40 };
    }
}
