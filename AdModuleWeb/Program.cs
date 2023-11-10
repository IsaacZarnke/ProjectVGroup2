using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//this is how you tell the entire App that you will be using the data folder, entity framework, along w connection string to manage backend database
//1. create connection string in app settings.json
//2. Create a folder for Data where all the tables will be created based off models (code first DB mmgmt)
//3. create a "Name"DbContext class and make it a child of DbContext class (base class)
//4. install entity framework to access DbContext class
//5. create constructor that takes a (vector?) datatype of DbContextOptions<NameDbContext> and name it options - use :base(options) syntax to pass into base class
//6. Instal EntityFramework Sql Server as you transition into the app(program.cs) to connect it all
//7. include code below to connect everything together and so app is aware how database is to be set up
//8.
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
//    builder.Configuration.GetConnectionString("DefaultConnection")
// ));
//between builder and calling Build is where you add in any dependency injections

var app = builder.Build();

app.MapGet("/", (IWebHostEnvironment env) =>
{
    // Path to your HTML file
    var filePath = Path.Combine(env.ContentRootPath, "wwwroot", "index.html");

    // Return the HTML file
    return Results.File(filePath, "text/html");
});

app.MapGet("/api/product/{id}", (string id) =>
{
    var imageUrl = "";
    // Test general id that dictates the state of the marketing module
    if (id != "000000")
    {
        imageUrl = CustomerMarketingAlgorithm();
    }
    else
    {
        imageUrl = GeneralMarketingAlgorithm();
    }

    // Prepare the HTML response with an image (and id temporarily for testing purposes)
    var htmlResponse = $"<html><body><h1>Customer ID: {id}</h1><img src=\"{imageUrl}\"></body></html>";

    // Return the HTML response
    return Results.Text(htmlResponse, "text/html");
});

app.Run();


// this would be the path the code takes if the customer user id is provided
static string CustomerMarketingAlgorithm()
{
    Console.WriteLine("CustomerMarketingAlgorithm called");

    // the image url would be a dynamic image src gathered from the algorithm (and database if required) returning the correct image for the ad spot
    var imageUrl = "https://picsum.photos/200/300";
    return imageUrl;
}