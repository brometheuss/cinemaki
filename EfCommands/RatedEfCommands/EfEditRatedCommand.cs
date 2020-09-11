using Application.DataTransfer;
using Application.Exceptions;
using Application.ICommands.RatedCommands;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EfCommands.RatedEfCommands
{
    public class EfEditRatedCommand : EfBaseCommand, IEditRatedCommand
    {
        public EfEditRatedCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 53;

        public string Name => "Edit Rated using EntityFramework";

        public void Execute(RatedDto dto)
        {
            var rating = Context.Rateds.Find(dto.Id);

            if (rating == null || rating.IsDeleted == true)
                throw new EntityNotFoundException("Rating");

            if (dto.Name.ToLower() != rating.Name.ToLower() && Context.Rateds.Any(r => r.Name.ToLower() == dto.Name.ToLower()))
                throw new EntityAlreadyExistsException("Rating");

            rating.Name = dto.Name;

            Context.SaveChanges();
        }
    }
}
