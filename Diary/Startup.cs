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

            #region �ֶ�����ע�뷽ʽ
            //services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IUserService, UserService>();
            #endregion
            // ����ע��
            services.RegisterServices(new List<string> { 
                "Diary.BLL",
                "Diary.DAL"
            });
            // ���AutoMapper
            services.AddAutoMapperAssembly("Diary.BLL");

            services.AddControllers(options =>
            {
                options.Filters.Add(new BussinessExceptionFilter());
            });
            services.AddMvc(options =>
            {
                // ����ģ����֤
                options.Filters.Add<ModelValidationAttribute>();
                // �Զ���API���ظ�ʽ
                options.Filters.Add<ApiResultFilterAttribute>();
            });
            // �ر�ģ���Զ���֤
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
