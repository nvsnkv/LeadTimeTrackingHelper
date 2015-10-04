using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using TeamUtils.LeadTimeTrackingHelper.Domain.Data;
using TeamUtils.LeadTimeTrackingHelper.Domain;
using Microsoft.Data.Entity;

namespace TeamUtils.LeadTimeTrackingHelper
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=.\SQLEXPRESS;Database=LeadTimeTracking;User=ef_local;Password=ef_password";
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<Repository.Context>(options => options.UseSqlServer(connection));

            services.AddTransient<Repository>();
            services.AddTransient<ChangeTracker>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseErrorPage();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller}/{action}",
                                new { controller = "Report", action = "Index" }
                    );
            });
        }
    }
}
