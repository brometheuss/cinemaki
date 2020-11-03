using Application.DataTransfer;
using Application.ICommands;
using Application.Interfaces;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands
{
    public class EfLoginUserCommand : EfBaseCommand, ILoginUserCommand
    {
        public EfLoginUserCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 76;

        public string Name => "Login";

        public ShowUserDto Execute(LoginUserDto request)
        {
            var user = Context.Users
                .Include(u => u.Cases)
                .Include(r => r.Role)
                .Where(x => x.Email.ToLower() == request.Email.ToLower()).Where(p => p.Password == request.Password).FirstOrDefault();

            /*var user = Context.Users.Where(x => x.Email.ToLower() == request.Email.ToLower()).Where(p => p.Password == request.Password).FirstOrDefault();*/

            if (user == null || user.IsDeleted == true)
                throw new ArgumentException("Invalid credentials, try again.");

            return new ShowUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Id = user.Id,
                RoleId = user.RoleId,
                Username = user.Username,
                RoleName = user.Role.Name,
                Cases = user.Cases.Select(x => x.Number).ToList()
            };

            //return new ShowUserDto
            //{
            //    FirstName = "Uros",
            //    LastName = "Markov",
            //    Email = "uros@email.com",
            //    Username = "maki",
            //    RoleId = 2
            //};
        }
    }
}
