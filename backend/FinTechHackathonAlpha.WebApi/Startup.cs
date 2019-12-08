using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinTechHackathonAlpha.WebApi.OfficialAccount;
using FinTechHackathonAlpha.WebApi.Repository;
using FinTechHackathonAlpha.WebApi.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace FinTechHackathonAlpha.WebApi
{
    public class Startup
    {
	    private const string ApiName = "FinPass.WebApi";
	    private const string ApiVersion = "v1";

		public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
	        services.AddCors();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

	        services.AddSwaggerGen(c =>
	        {
		        c.SwaggerDoc(ApiVersion, new Info
		        {
			        Title = ApiName,
			        Version = ApiVersion,
			        Description = "FinPass WebAPI"
				});
	        });

	        services.AddDbContext<FinPassDbContext>(options =>
		        options.UseSqlite(Configuration.GetConnectionString("SqliteConnection")));

			services.AddSingleton<IEchoUrlValidator, EchoUrlValidator>();
	        services.AddScoped<IProfileRepository, ProfileRepository>();
	        services.AddScoped<IProfileArtifactRepository, ProfileArtifactRepository>();
	        services.AddScoped<IDocumentService, DocumentService>();
	        services.AddScoped<IFillFormService, FillFormService>();
        }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
	        app.UseSwagger();

	        app.UseSwaggerUI(c =>
	        {
		        c.SwaggerEndpoint($"/swagger/{ApiVersion}/swagger.json", $"{ApiName} {ApiVersion}");
	        });

			if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

	        app.UseCors();
			app.UseMvc();
        }
    }
}
