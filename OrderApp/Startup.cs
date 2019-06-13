using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderApp.Common;
using OrderApp.Services.Abstract;
using OrderApp.Services.Abstract.Common;
using OrderApp.Services.Implementation;
using OrderApp.Services.Implementation.Common;
using Swashbuckle.AspNetCore.Swagger;

namespace OrderApp
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
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.Configure<Settings>(Configuration.GetSection("Settings"));

            services.AddDbContext<OrdersDBContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IImportOrdersService, ImportOrdersService>();
			services.AddTransient<IOrdersFilterRepository, OrdersFilterService>();
			services.AddTransient<ISetInvoiceNumberService, SetInvoiceNumberService>();
			services.AddTransient<ISetOrderStatusService, SetOrderStatusService>();
			services.AddTransient<IPaymentsRepository, PaymentsRepository>();
			services.AddTransient<IBillingAddressesRepository, BillingAddressesRepository>();
			services.AddTransient<IOrderRepository, OrderRepository>();
			services.AddTransient<IArticlesRepository, ArticlesRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });
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
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

			app.UseMvc(routes => {

                routes.MapRoute(
                   name: "default",
                   template: "api/{controller}/{action}");                

            });
		}
	}
}
