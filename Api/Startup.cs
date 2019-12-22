using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ICommands.ActorCommands;
using Application.ICommands.CountryCommands;
using Application.ICommands.GenreCommands;
using Application.ICommands.MovieCommands;
using Application.ICommands.ProductionCommands;
using Application.ICommands.RatedCommands;
using Application.ICommands.RoleCommands;
using Application.ICommands.UserCommands;
using EfCommands.ActorEfCommands;
using EfCommands.CountryEfCommands;
using EfCommands.GenreEfCommands;
using EfCommands.MovieEfCommands;
using EfCommands.ProductionEfCommands;
using EfCommands.RatedEfCommands;
using EfCommands.RoleEfCommands;
using EfCommands.UserEfCommands;
using EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<EfCinemakContext>();

            //UsersController
            services.AddTransient<IGetUsersCommand, EfGetUsersCommand>();
            services.AddTransient<IGetUserCommand, EfGetUserCommand>();
            services.AddTransient<IAddUserCommand, EfAddUserCommand>();
            services.AddTransient<IEditUserCommand, EfEditUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();

            //RolesController
            services.AddTransient<IGetRolesCommand, EfGetRolesCommand>();
            services.AddTransient<IGetRoleCommand, EfGetRoleCommand>();
            services.AddTransient<IAddRoleCommand, EfAddRoleCommand>();
            services.AddTransient<IEditRoleCommand, EfEditRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EfDeleteRoleCommand>();

            //MoviesController
            services.AddTransient<IGetMoviesCommand, EfGetMoviesCommand>();
            services.AddTransient<IGetMovieCommand, EfGetMovieCommand>();
            services.AddTransient<IAddMovieCommand, EfAddMovieCommand>();

            //GenresController
            services.AddTransient<IGetGenresCommand, EfGetGenresCommand>();
            services.AddTransient<IGetGenreCommand, EfGetGenreCommand>();
            services.AddTransient<IAddGenreCommand, EfAddGenreCommand>();
            services.AddTransient<IEditGenreCommand, EfEditGenreCommand>();
            services.AddTransient<IDeleteGenreCommand, EfDeleteGenreCommand>();

            //CountriesController
            services.AddTransient<IGetCountriesCommand, EfGetCountriesCommand>();
            services.AddTransient<IGetCountryCommand, EfGetCountryCommand>();
            services.AddTransient<IAddCountryCommand, EfAddCountryCommand>();
            services.AddTransient<IEditCountryCommand, EfEditCountryCommand>();
            services.AddTransient<IDeleteCountryCommand, EfDeleteCountryCommand>();

            //RatedsController
            services.AddTransient<IGetRatedsCommand, EfGetRatedsCommand>();
            services.AddTransient<IGetRatedCommand, EfGetRatedCommand>();
            services.AddTransient<IAddRatedCommand, EfAddRatedCommand>();
            services.AddTransient<IEditRatedCommand, EfEditRatedCommand>();
            services.AddTransient<IDeleteRatedCommand, EfDeleteRatedCommand>();

            //ProductionsController
            services.AddTransient<IGetProductionsCommand, EfGetProductionsCommand>();
            services.AddTransient<IGetProductionCommand, EfGetProductionCommand>();
            services.AddTransient<IAddProductionCommand, EfAddProductionCommand>();
            services.AddTransient<IEditProductionCommand, EfEditProductionCommand>();
            services.AddTransient<IDeleteProductionCommand, EfDeleteProductionCommand>();

            //ActorsController
            services.AddTransient<IGetActorsCommand, EfGetActorsCommand>();
            services.AddTransient<IGetActorCommand, EfGetActorCommand>();
            services.AddTransient<IAddActorCommand, EfAddActorCommand>();
            services.AddTransient<IEditActorCommand, EfEditActorCommand>();
            services.AddTransient<IDeleteActorCommand, EfDeleteActorCommand>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
