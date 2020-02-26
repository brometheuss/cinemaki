using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ICommands.ActorCommands;
using Application.ICommands.CountryCommands;
using Application.ICommands.GenreCommands;
using Application.ICommands.HallCommands;
using Application.ICommands.LanguageCommands;
using Application.ICommands.MovieCommands;
using Application.ICommands.PosterCommands;
using Application.ICommands.ProductionCommands;
using Application.ICommands.RatedCommands;
using Application.ICommands.RoleCommands;
using Application.ICommands.UserCommands;
using Application.ICommands.WriterCommands;
using EfCommands.ActorEfCommands;
using EfCommands.CountryEfCommands;
using EfCommands.GenreEfCommands;
using EfCommands.HallEfCommands;
using EfCommands.LanguageEfCommands;
using EfCommands.MovieEfCommands;
using EfCommands.PosterEfCommands;
using EfCommands.ProductionEfCommands;
using EfCommands.RatedEfCommands;
using EfCommands.RoleEfCommands;
using EfCommands.UserEfCommands;
using EfCommands.WriterEfCommand;
using EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebMVC
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
            services.AddControllersWithViews();
            services.AddDbContext<EfCinemakContext>();
            services.AddCloudscribePagination();

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

            //GenresController
            services.AddTransient<IGetGenresCommand, EfGetGenresCommand>();
            services.AddTransient<IGetGenreCommand, EfGetGenreCommand>();
            services.AddTransient<IAddGenreCommand, EfAddGenreCommand>();
            services.AddTransient<IEditGenreCommand, EfEditGenreCommand>();
            services.AddTransient<IDeleteGenreCommand, EfDeleteGenreCommand>();

            //ActorsController
            services.AddTransient<IGetActorsCommand, EfGetActorsCommand>();
            services.AddTransient<IGetActorCommand, EfGetActorCommand>();
            services.AddTransient<IAddActorCommand, EfAddActorCommand>();
            services.AddTransient<IEditActorCommand, EfEditActorCommand>();
            services.AddTransient<IDeleteActorCommand, EfDeleteActorCommand>();

            //WritersController
            services.AddTransient<IGetWritersCommand, EfGetWritersCommand>();
            services.AddTransient<IGetWriterCommand, EfGetWriterCommand>();
            services.AddTransient<IAddWriterCommand, EfAddWriterCommand>();
            services.AddTransient<IEditWriterCommand, EfEditWriterCommand>();
            services.AddTransient<IDeleteWriterCommand, EfDeleteWriterCommand>();

            //LanguagesController
            services.AddTransient<IGetLanguagesCommand, EfGetLanguagesCommand>();
            services.AddTransient<IGetLanguageCommand, EfGetLanguageCommand>();
            services.AddTransient<IAddLanguageCommand, EfAddLanguageCommand>();
            services.AddTransient<IEditLanguageCommand, EfEditLanguageCommand>();
            services.AddTransient<IDeleteLanguageCommand, EfDeleteLanguageCommand>();

            //MoviesController
            services.AddTransient<IGetMoviesCommand, EfGetMoviesCommand>();
            services.AddTransient<IGetMovieCommand, EfGetMovieCommand>();
            services.AddTransient<IAddMovieCommand, EfAddMovieCommand>();
            services.AddTransient<IEditMovieCommand, EfEditMovieCommand>();
            services.AddTransient<IDeleteMovieCommand, EfDeleteMovieCommand>();

            //CountriesController
            services.AddTransient<IGetCountriesCommand, EfGetCountriesCommand>();
            services.AddTransient<IGetCountryCommand, EfGetCountryCommand>();
            services.AddTransient<IAddCountryCommand, EfAddCountryCommand>();
            services.AddTransient<IEditCountryCommand, EfEditCountryCommand>();
            services.AddTransient<IDeleteCountryCommand, EfDeleteCountryCommand>();

            //ProductionsController
            services.AddTransient<IGetProductionsCommand, EfGetProductionsCommand>();
            services.AddTransient<IGetProductionCommand, EfGetProductionCommand>();
            services.AddTransient<IAddProductionCommand, EfAddProductionCommand>();
            services.AddTransient<IEditProductionCommand, EfEditProductionCommand>();
            services.AddTransient<IDeleteProductionCommand, EfDeleteProductionCommand>();

            //RatedsController
            services.AddTransient<IGetRatedsCommand, EfGetRatedsCommand>();
            services.AddTransient<IGetRatedCommand, EfGetRatedCommand>();
            services.AddTransient<IAddRatedCommand, EfAddRatedCommand>();
            services.AddTransient<IEditRatedCommand, EfEditRatedCommand>();
            services.AddTransient<IDeleteRatedCommand, EfDeleteRatedCommand>();

            //HallsController
            services.AddTransient<IGetHallsCommand, EfGetHallsCommand>();
            services.AddTransient<IGetHallCommand, EfGetHallCommand>();
            services.AddTransient<IAddHallCommand, EfAddHallCommand>();
            services.AddTransient<IEditHallCommand, EfEditHallCommand>();
            services.AddTransient<IDeleteHallCommand, EfDeleteHallCommand>();

            //PostersController
            services.AddTransient<IGetPostersCommand, EfGetPostersCommand>();
            services.AddTransient<IGetPosterCommand, EfGetPosterCommand>();
            services.AddTransient<IAddPosterCommand, EfAddPosterCommand>();
            services.AddTransient<IEditPosterCommand, EfEditPosterCommand>();
            services.AddTransient<IDeletePosterCommand, EfDeletePosterCommand>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
