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

            // �������ļ�д��ǿ����
            services.Configure<TokenOptions>(Configuration.GetSection(TokenOptions.Options));
            var token = Configuration.GetSection(TokenOptions.Options).Get<TokenOptions>();

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

            #region JWT
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o => {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    //�Ƿ���֤������
                    ValidateIssuer = true,
                    ValidIssuer = token.Issurer,    //������                          
                    ValidateAudience = true,        //�Ƿ���֤������
                    ValidAudience = token.Audience, //������
                    ValidateIssuerSigningKey = true,//�Ƿ���֤��Կ
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Sign)),
                    ValidateLifetime = true, //��֤��������
                    RequireExpirationTime = true, //����ʱ��
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
            //�ȿ�����֤
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
