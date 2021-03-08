using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.DataTransfer;
using Application.Helpers;
using Application.ICommands;
using Application.ICommands.ActorCommands;
using Application.ICommands.CommentCommands;
using Application.ICommands.CountryCommands;
using Application.ICommands.GenreCommands;
using Application.ICommands.HallCommands;
using Application.ICommands.IHelperCommands;
using Application.ICommands.LanguageCommands;
using Application.ICommands.LogCommands;
using Application.ICommands.MovieCommands;
using Application.ICommands.PosterCommands;
using Application.ICommands.ProductionCommands;
using Application.ICommands.ProjectionCommands;
using Application.ICommands.RatedCommands;
using Application.ICommands.ReservationCommands;
using Application.ICommands.RoleCommands;
using Application.ICommands.SeatCommands;
using Application.ICommands.UserCommands;
using Application.ICommands.WriterCommands;
using Application.Interfaces;
using EfCommands;
using EfCommands.ActorEfCommands;
using EfCommands.CommentEfCommands;
using EfCommands.CountryEfCommands;
using EfCommands.GenreEfCommands;
using EfCommands.HallEfCommands;
using EfCommands.HelperCommands;
using EfCommands.LanguageEfCommands;
using EfCommands.LogEfCommands;
using EfCommands.MovieEfCommands;
using EfCommands.PosterEfCommands;
using EfCommands.ProductionEfCommands;
using EfCommands.ProjectionEfCommands;
using EfCommands.RatedEfCommands;
using EfCommands.ReservationEfCommands;
using EfCommands.RoleEfCommands;
using EfCommands.SeatEfCommands;
using EfCommands.UserEfCommands;
using EfCommands.WriterEfCommand;
using EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebMVC.Session;

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
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(15);
            });

            //HelperController
            services.AddTransient<IAutoAddSeatValuesCommand, EfAutoAddSeatValuesCommand>();
            services.AddTransient<ITakenSeatsCommand, EfTakenSeatsCommand>();

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

            //CommentsController
            services.AddTransient<IGetCommentsCommand, EfGetCommentsCommand>();
            services.AddTransient<IGetCommentCommand, EfGetCommentCommand>();
            services.AddTransient<IAddCommentCommand, EfAddCommentCommand>();
            services.AddTransient<IEditCommentCommand, EfEditCommentCommand>();
            services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();

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

            //ReservationsController
            services.AddTransient<IGetReservationsCommand, EfGetReservationsCommand>();
            services.AddTransient<IGetReservationCommand, EfGetReservationCommand>();
            services.AddTransient<IAddReservationCommand, EfAddReservationCommand>();
            services.AddTransient<IDeleteReservationCommand, EfDeleteReservationCommand>();

            //HallsController
            services.AddTransient<IGetHallsCommand, EfGetHallsCommand>();
            services.AddTransient<IGetHallCommand, EfGetHallCommand>();
            services.AddTransient<IAddHallCommand, EfAddHallCommand>();
            services.AddTransient<IEditHallCommand, EfEditHallCommand>();
            services.AddTransient<IDeleteHallCommand, EfDeleteHallCommand>();

            //SeatsController
            services.AddTransient<IGetSeatsCommand, EfGetSeatsCommand>();
            services.AddTransient<IGetSeatCommand, EfGetSeatCommand>();
            services.AddTransient<IAddSeatCommand, EfAddSeatCommand>();
            services.AddTransient<IEditSeatCommand, EfEditSeatCommand>();
            services.AddTransient<IDeleteSeatCommand, EfDeleteSeatCommand>();

            //PostersController
            services.AddTransient<IGetPostersCommand, EfGetPostersCommand>();
            services.AddTransient<IGetPosterCommand, EfGetPosterCommand>();
            services.AddTransient<IAddPosterCommand, EfAddPosterCommand>();
            services.AddTransient<IEditPosterCommand, EfEditPosterCommand>();
            services.AddTransient<IDeletePosterCommand, EfDeletePosterCommand>();

            //ProjectionsController
            services.AddTransient<IGetProjectionsCommand, EfGetProjectionsCommand>();
            services.AddTransient<IGetProjectionCommand, EfGetProjectionCommand>();
            services.AddTransient<IAddProjectionCommand, EfAddProjectionCommand>();
            services.AddTransient<IEditProjectionCommand, EfEditProjectionCommand>();
            services.AddTransient<IDeleteProjectionCommand, EfDeleteProjectionCommand>();

            //AccountController
            services.AddHttpContextAccessor();
            services.AddTransient<ILoginUserCommand, EfLoginUserCommand>();
            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<IUseCaseLogger, EfUseCaseLoggerCommand>();
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.Session.Get<ShowUserDto>("User");
                DefaultApplicationActor guest = new DefaultApplicationActor();

                if (user == null)
                    return guest;

                    return user;
            });

            //LogsController
            services.AddTransient<IGetLogsCommand, EfGetLogsCommand>();
            services.AddTransient<IGetLogCommand, EfGetLogCommand>();
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
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
