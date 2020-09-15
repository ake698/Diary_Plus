using System.Collections.Generic;
using AutoMapper;
using Diary.Entity;
using Diary.Extension;
using Diary.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
