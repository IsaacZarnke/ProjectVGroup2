using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Drawing.Imaging;
using System.Drawing;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using ikvm.runtime;

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

    var imageUrl = CustomerMarketingAlgorithm();

    // Prepare the HTML response with an image (and id temporarily for testing purposes)
    var htmlResponse = $"<a href=\"{imageUrl}\"></a>";

    // Return the HTML response
    return Results.Redirect(imageUrl);
});

app.MapPost("/api/parsejson", async (HttpContext context) =>
{
    using (StreamReader reader = new StreamReader(context.Request.Body))
    {
        var json = await reader.ReadToEndAsync();

        var result = parseJSON(json);

        if (result == 1)
        {
            return Results.Ok();
        }
        else
        {
            return Results.BadRequest("Unrecognized JSON structure");
        }
    }
});

int parseJSON(string json)
{
    return 1;
}

app.Run();

// this would be the path the code takes if the customer user id is provided
static string CustomerMarketingAlgorithm()
{
    Console.WriteLine("CustomerMarketingAlgorithm called");

    // the image url would be a dynamic image src gathered from the algorithm (and database if required) returning the correct image for the ad spot
    var imageUrl = "https://picsum.photos/650/250.jpg";
    return imageUrl;
}

static void AdCreativeTransformer(string url) //takes in a product image url, overlays ad creative, saves final ad as ad output.png within AdCreatives folder
{
    Image imageAdTemplate = Image.FromFile("/AdCreatives/overlay.png");
    using (WebClient client = new WebClient())
    {
        client.DownloadFile(url, "AdCreatives/product.png");
    }
    Image imageProduct = Image.FromFile("AdCreatives/product.png");

    Image img = new Bitmap(imageAdTemplate.Width, imageAdTemplate.Height);
    using (Graphics gr = Graphics.FromImage(img))
    {
        gr.DrawImage(imageAdTemplate, new Point(0, 0));
        gr.DrawImage(imageProduct, new Point(0, 0));
    }
    img.Save("AdCreatives/ad output.png", ImageFormat.Png);

}