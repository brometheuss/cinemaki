using Application.DataTransfer;
using Application.Exceptions;
using Application.Helpers;
using Application.ICommands.PosterCommands;
using Domain;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EfCommands.PosterEfCommands
{
    public class EfAddPosterCommand : EfBaseCommand, IAddPosterCommand
    {
        public EfAddPosterCommand(EfCinemakContext context) : base(context)
        {
        }

        public int Id => 36;

        public string Name => "Add Poster using EntityFramework";

        public void Execute(PosterDto request)
        {
            var ext = Path.GetExtension(request.Image.FileName);
            var size = request.Image.Length;

            if (size / 1000 > 4096)
                throw new EntityNotAllowedException("File size bigger than 4MB");

            if (!FileUpload.AllowedExtensions.Contains(ext))
                throw new EntityNotAllowedException("Extension " + ext);

            var newFileName = Guid.NewGuid().ToString() + "_" + request.Image.FileName;

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);

            request.Image.CopyTo(new FileStream(filePath, FileMode.Create));

            Context.Posters.Add(new Poster
            {
                PosterTitle = request.PosterTitle,
                Alt = request.Alt,
                Name = newFileName,
                MovieId = request.MovieId,
            });

            Context.SaveChanges();
        }
    }
}
