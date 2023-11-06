using AdModuleWeb.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//this is how you tell the entire App that you will be using the data folder, entity framework, along w connection string to manage backend database 
//1. create connection string in app settings.json
//2. Create a folder for Data where all the tables will be created based off models (code first DB mmgmt)
//3. create a "Name"DbContext class and make it a child of DbContext class (base class)
//4. install entity framework to access DbContext class 
//5. create constructor that takes a (vector?) datatype of DbContextOptions<NameDbContext> and name it options - use :base(options) syntax to pass into base class
//6. Instal EntityFramework Sql Server as you transition into the app(program.cs) to connect it all 
//7. include code below to connect everything together and so app is aware how database is to be set up
//8.  
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")    
 ));
//between builder and calling Build is where you add in any dependency injections 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//all the middleware in the pipleline down below placed before the first controllorer route
app.UseHttpsRedirection();

//use static files in www.root folder
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
