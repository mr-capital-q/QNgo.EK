using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QNgo.EK.Abstractions;
using QNgo.EK.App.Server.Hubs;
using QNgo.EK.App.Server.Services;
using QNgo.EK.Engine;
using QNgo.EK.Engine.GameActions.CardActions;
using QNgo.EK.Engine.GameActions.PlayerActions;
using System.Linq;

namespace QNgo.EK.App.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            services.AddTransient<GameHub>();
            services.AddTransient<TurnEngine>();
            services.AddTransient<IGameState, GameState>();
            services.AddTransient<IGameActionResolver, GameActionResolver>();
            services.AddTransient<ICardResolver, CardResolver>();

            services.AddTransient<DrawPlayerAction>();
            services.AddTransient<ExtraLifeAction>();
            services.AddTransient<SkipCardAction>();
            services.AddTransient<ShuffleCardAction>();
            //services.AddTransient<PeekDeckCardAction>();
            //services.AddTransient<AlterDeckCardAction>();

            services.AddTransient<IGameStateNotifier, GameStateNotifier>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapHub<GameHub>("/gameHub");
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
