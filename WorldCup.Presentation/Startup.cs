using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorldCup.Application;
using WorldCup.Application.Interfaces;
using WorldCup.Domain.Entities;
using WorldCup.Domain.Interfaces.Repositories;
using WorldCup.DomainService.Interfaces;
using WorldCup.DomainService.Services;
using WorldCup.Infra.InMemory.Context;
using WorldCup.Infra.InMemory.Repositories;

namespace WorldCup.Presentation
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
            services.AddDbContext<WorldCupContext>(opt => opt.UseInMemoryDatabase(databaseName: "WorldCupDB"));
            services.AddTransient<IBaseAppService<Team>, BaseAppService<Team>>();
            services.AddTransient<ITeamAppService, TeamAppService>();
            services.AddTransient<IRafflesAppService, RafflesAppService>();
            services.AddTransient<IMatchAppService, MatchAppService>();

            services.AddTransient<IBaseService<Team>, BaseService<Team>>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IRafflesService, RafflesService>();
            services.AddTransient<IMatchService, MatchService>();

            services.AddTransient<IBaseRepository<Team>, BaseRepository<Team>>();
            services.AddTransient<ITeamRepository, TeamRepository>();            

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Team}/{action=Index}/{id?}");
            });
        }
    }
}
