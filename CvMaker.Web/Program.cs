using AutoMapper;
using CvMaker.Core.Models;
using CvMaker.Core.Services;
using CvMaker.Data;
using CvMaker.Services;
using CvMaker.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CvMaker.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CvDbContext>
            (options => options.UseSqlServer
                (builder.Configuration.GetConnectionString("cvDb")));
            var mapper = AutoMapperConfig.Configure();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddTransient<IDbService, DbService>();
            builder.Services.AddTransient
                <IEntityService<CurriculumVitae>, EntityService<CurriculumVitae>>();
            builder.Services.AddScoped<ICurriculumVitaeService, CurriculumVitaeService>();


            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}