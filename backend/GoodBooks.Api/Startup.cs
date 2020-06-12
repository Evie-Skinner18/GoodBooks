using dotenv.net;
using dotenv.net.Utilities;
using GoodBooks.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using GoodBooks.Services;
using GoodBooks.Services.Readers;
using GoodBooks.Services.Writers;

namespace GoodBooks.Api
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
            // 'services' is the IOC container
            services.AddCors();
            services.AddControllers();

            // set up dotenv to grab the env vars
            DotEnv.Config(true, "../.env");
            var envReader = new EnvReader();
            var connectionString = envReader.GetStringValue("DEV_CONNECTION_STRING");

            // set up Postgres
            services.AddEntityFrameworkNpgsql();
            services.AddDbContext<GoodBooksDbContext>(options => 
            {
                options.EnableDetailedErrors();
                options.UseNpgsql(connectionString);
            });

            // register dependencies in the IOC container. When I ask for IBookService, please use the BookService implementation
            // AddTransient means we want a simple, short-lived instance of a BookService when its behaviour is requested
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBookDataReader, BookDataReader>();
            services.AddTransient<IBookDataWriter, BookDataWriter>();
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


            // our Vue front end will operate completely separately on a different host. For that reason we need to enable CORS to allow front end to consume API from where it's hosted
            // (Vue is on localh ost 8080) and no other client is allowed, for security
            app.UseCors(builder => builder 
                .WithOrigins("https://localhost:8080")
                .AllowAnyMethod()
                .AllowAnyHeader()
           );
        }
    }
}
