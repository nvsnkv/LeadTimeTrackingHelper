using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using TeamUtils.LeadTimeTrackingHelper.Domain.Data;
using Microsoft.Data.Entity;

namespace TeamUtils.LeadTimeTrackingHelper
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=.\SQLEXPRESS;Database=LeadTimeTracking;Trusted_Connection=True;";

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<Repository.Context>(options => options.UseSqlServer(connection));

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
