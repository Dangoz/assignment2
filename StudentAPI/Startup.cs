using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using StudentAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI
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
      var host = Configuration["DBHOST"] ?? "localhost";
      var port = Configuration["DBPORT"] ?? "1444";
      var user = Configuration["DBUSER"] ?? "sa";
      var pwd = Configuration["DBPASSWORD"] ?? "SqlExpress!";
      var db = Configuration["DBNAME"] ?? "a2";

      var conStr = $"Server=tcp:{host},{port};Database={db};UID={user};PWD={pwd};";
      services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(conStr));

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "StudentAPI", Version = "v1" });
      });

      // services.AddDbContext<SchoolDbContext>(
      //   option => option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      // Add Cors
      services.AddCors(o => o.AddPolicy("Policy", builder =>
      {
        builder.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader();
      }));

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, StudentDbContext context)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StudentAPI v1"));
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors("Policy");

      app.UseAuthorization();

      context.Database.Migrate();
      // SampleData.Initialize(app);

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
