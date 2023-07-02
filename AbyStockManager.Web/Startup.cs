using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Aby.StockManager.Core.Repository;
using Aby.StockManager.Core.Service;
using Aby.StockManager.Core.UnitOfWorks;
using Aby.StockManager.Data.Context;
using Aby.StockManager.Repository.Base;
using Aby.StockManager.Service.Category;
using Aby.StockManager.Service.Product;
using Aby.StockManager.Service.Store;
using Aby.StockManager.Service.StoreStock;
using Aby.StockManager.Service.Transaction;
using Aby.StockManager.Service.UnitOfMeasure;
using Aby.StockManager.Service.User;
using AbyStockManager.Web.Service.Tax;
using Aby.StockManager.Service;
using Aby.StockManager.Data.Entity;

namespace Aby.StockManager.Web
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
            //services.AddDbContext<EasyStockManagerDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration["ConnectionStrings:SqlConStr"].ToString());
            //});

            services.AddDbContext<EasyStockManagerDbContext>(options =>
                    options.UseSqlite("Data Source=add-expenses.db"));

            services.AddAutoMapper(c => c.AddProfile<Aby.StockManager.Mapper.MapProfile>(), typeof(Startup));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();
            services.AddScoped<ITaxService, TaxService>();
            services.AddScoped<IUnitOfMeasureService, UnitOfMeasureService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IExpenseReportService, ExpenseReportService>();
            services.AddScoped<IStoreStockService, StoreStockService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IUnitOfWorks, UnitOfWork.UnitOfWork>();
            services.AddControllersWithViews().
                    AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                        options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    }).AddRazorRuntimeCompilation();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
                AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
                     {
                         options.LoginPath = new PathString("/auth/login");
                         options.Cookie.HttpOnly = true;
                         options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
                         options.SlidingExpiration = true;
                     });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<EasyStockManagerDbContext>();
            context.Database.EnsureCreated();

            //if (context.ExpenseCategory.Any())
            //{
            //    var expenseCategory = context.ExpenseCategory.ToList();
            //    context.ExpenseCategory.RemoveRange(expenseCategory);
            //    context.SaveChanges();

            //    var list = new List<ExpenseCategory>
            //    {
            //        new ExpenseCategory { Id = 1, CategoryName = "Snacks", CreateDate = DateTime.Now },
            //        new ExpenseCategory { Id = 2, CategoryName = "Rent", CreateDate = DateTime.Now },
            //        new ExpenseCategory { Id = 3, CategoryName = "Travel", CreateDate = DateTime.Now },
            //        new ExpenseCategory { Id = 4, CategoryName = "Utilities", CreateDate = DateTime.Now },
            //        new ExpenseCategory { Id = 5, CategoryName = "Water", CreateDate = DateTime.Now },
            //        new ExpenseCategory { Id = 6, CategoryName = "Wage", CreateDate = DateTime.Now },
            //        new ExpenseCategory { Id = 7, CategoryName = "Other", CreateDate = DateTime.Now }
            //    };

            //    context.ExpenseCategory.AddRange(list);
            //    context.SaveChanges();
            //}

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Transaction}/{action=Index}/{id?}")
                .RequireAuthorization();
            });
        }
    }
}