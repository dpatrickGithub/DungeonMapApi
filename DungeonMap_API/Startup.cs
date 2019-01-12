using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DungeonMap_API.Hubs;
using DungeonMap_API.Repositories;
using DungeonMap_API.Services;
using DungeonMap_API.Services.Auth;
using DungeonMap_API.Services.Character;
using DungeonMap_Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DungeonMap_API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<DungeonMapContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DungeonMapDatabase"),
                x => x.MigrationsAssembly("DungeonMap_Entities")));

            //Repositories
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            //Services
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<ICharacterService, CharacterService>();
            services.AddScoped<IDiceService, DiceService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chat");
                routes.MapHub<MapHub>("/map");
            });
            app.UseMvc();
        }
    }
}
