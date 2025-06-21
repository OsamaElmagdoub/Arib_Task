using Arib_Task.ApplicationDbContext;
using Arib_Task.Mapping_Proile;
using Arib_Task.Models;
using Arib_Task.Repository;
using Arib_Task.Repository.Category_Repository;
using Arib_Task.Repository.Department_Repository;
using Arib_Task.Repository.Employee_Repository;
using Arib_Task.Repository.Manager_Repository;
using Arib_Task.Repository.ProductRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ManagerRepository = Arib_Task.Repository.Manager_Repository.ManagerRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ImanagerRepository,ManagerRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()

    .AddEntityFrameworkStores<AppDbContext>() // استخدم اسم DbContext اللي فيه IdentityUser
    .AddDefaultTokenProviders();


var app = builder.Build();

    var scope = app.Services.CreateScope();
    var userManger = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = new[] { "Manager", "Employee" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }



    var managerUserName = "Manager_10";
    var manager = await userManger.FindByNameAsync(managerUserName);
    if (manager == null)
    {
        var managerUser = new ApplicationUser
        { UserName = managerUserName, Email = managerUserName, FullName = "Manager" };
        await userManger.CreateAsync(managerUser, "Manager@123");
        await userManger.AddToRoleAsync(managerUser, "Manager");
    }

var employeeUserName = "Employee_10";
var employee = await userManger.FindByNameAsync(employeeUserName);
if (employee == null)
{
    var employeeUser = new ApplicationUser
    { UserName = employeeUserName, Email = employeeUserName, FullName = "Employee" };
    await userManger.CreateAsync(employeeUser, "Employee@123");
    await userManger.AddToRoleAsync(employeeUser, "Employee");
}


    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.Migrate();

    if (!context.Managers.Any())
    {
        var department1 = context.Departments.FirstOrDefault(d => d.Name == "sales");
        var department2 = context.Departments.FirstOrDefault(d => d.Name == "hr");

        if (department1 != null && department2 != null)
        {
            var managers = new List<Manager>
            {
                new Manager { Name = "Osama", DepartmentId = department1.Id },
                new Manager { Name = "Ahmed", DepartmentId = department2.Id }
            };

            context.Managers.AddRange(managers);
            context.SaveChanges();
        }
    }




if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
