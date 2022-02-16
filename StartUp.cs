using Shop_Backend.lib.Database;
using Shop_Backend.src.Models.Articel;

namespace Shop_Backend
{
    public class Startup
    {
        private const string ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=backend;";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            DataBaseConnection connection = new DataBaseConnection(ConnectionString);
            services.AddSingleton(connection);
            services.AddSingleton(new ArticelModel(connection));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use((context, next) =>
            {
                context.Request.EnableBuffering();
                return next();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
