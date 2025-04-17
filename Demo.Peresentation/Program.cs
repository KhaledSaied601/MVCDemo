using Demo.BusinessLogic.Profiles;
using Demo.BusinessLogic.Services.Classes;
using Demo.BusinessLogic.Services.Interfaces;
using Demo.DataAccess.Contexts;
using Demo.DataAccess.Repositories.Classes;
using Demo.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Demo.Peresentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.

            // Add services to the container.
            builder.Services.AddControllersWithViews(option=>option.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));



            //Dependcy Injection for DB Context

            builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
            {


                optionsBuilder.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
                optionsBuilder.UseLazyLoadingProxies();

            });


            //   builder.Services.AddDbContext<AppDbContext>(optionsBuilder =>
            //optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();



            builder.Services.AddScoped<IEmployeeRepoistory,EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();


            //builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
            builder.Services.AddAutoMapper(p=>p.AddProfile(new MappingProfiles()));

            #endregion


            var app = builder.Build();


            #region Configure the HTTP request pipeline.

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion

            app.Run();
        }
    }
}
