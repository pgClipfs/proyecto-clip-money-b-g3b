using ClipMoney.Persistence.EntityFramework.context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ClipMoney.Domain.Repositories;
using ClipMoney.Application.BusinessLogics;
using AutoMapper;
using System.Reflection;
using ClipMoney.API.Configuration;

namespace ClipMoney.API
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
            services.AddAutoMapper(Assembly.Load("ClipMoney.Infrastructure.Automapper"));
            services.AddControllers();
            services.AddDbContext<BilleteraClipMoneyContext>(conf => conf.UseSqlServer(Configuration.GetConnectionString("clip-money-sqlserver")));
            services.AddControllers().AddNewtonsoftJson(c => c.UseMemberCasing());

            //services.AddControllers().AddNewtonsoftJson(c => c.UseMemberCasing());

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Jwt:Key"))),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddSwaggerDocumentation(Configuration);

            services.AddTransient<UserRepository>();
            services.AddTransient<UserBusinessLogic>();
            services.AddTransient<WalletRepository>();
            services.AddTransient<WalletBussinesLogic>();
            services.AddTransient<TransferRepository>();
            services.AddTransient<TransferBussinesLogic>();
            services.AddTransient<OpenTurnBussinesLogic>();
            services.AddTransient<OpenTurnRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerDoc(Configuration);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
