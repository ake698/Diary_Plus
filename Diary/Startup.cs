using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Diary.Bussiness;
using Diary.Entity;
using Diary.Extension;
using Diary.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Diary
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
            services.AddDbContext<DiaryContext>(options =>
            {
                //o.UseInMemoryDatabase("Demo")
                //options.UseMySQL(Configuration.GetConnectionString("MysqlSqlServerConnection"),
                //    p => p.MigrationsAssembly("Diary.Entity"));
                options.UseSqlServer(Configuration.GetConnectionString("SqlServerConnection"),
                    p => p.MigrationsAssembly("Diary.Entity"));
            }, ServiceLifetime.Scoped);

            // 将配置文件写入强类型
            services.Configure<TokenOptions>(Configuration.GetSection(TokenOptions.Options));
            var token = Configuration.GetSection(TokenOptions.Options).Get<TokenOptions>();

            #region 手动单个注入方式
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IUserService, UserService>();
            #endregion
            // 批量注入
            services.RegisterServices(new List<string> { 
                "Diary.BLL",
                "Diary.DAL"
            });
            // 添加AutoMapper
            services.AddAutoMapperAssembly("Diary.BLL");

            services.AddControllers(options =>
            {
                options.Filters.Add(new BussinessExceptionFilter());
            });
            services.AddMvc(options =>
            {
                // 更改模型验证
                options.Filters.Add<ModelValidationAttribute>();
                // 自定义API返回格式
                options.Filters.Add<ApiResultFilterAttribute>();
            });
            // 关闭模型自动验证
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            #region JWT
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o => {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    //是否验证发行人
                    ValidateIssuer = true,
                    ValidIssuer = token.Issurer,    //发行人                          
                    ValidateAudience = true,        //是否验证受众人
                    ValidAudience = token.Audience, //受众人
                    ValidateIssuerSigningKey = true,//是否验证密钥
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Sign)),
                    ValidateLifetime = true, //验证生命周期
                    RequireExpirationTime = true, //过期时间
                };
            });
            #endregion


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //先开启认证
            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
