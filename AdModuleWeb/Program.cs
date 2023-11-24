using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapGet("/", (IWebHostEnvironment env) =>
{
    // Path to your HTML file
    var filePath = Path.Combine(env.ContentRootPath, "wwwroot", "index.html");

    // Read the content of the HTML file
    var htmlContent = File.ReadAllText(filePath);

    // var CoversionClickDataset = getStatsFunction;

    // Generate JavaScript code with the initialized variable
    // var javascriptCode = $"<script>var CoversionClickDataset = '{CoversionClickDataset}';</script>";

    // Insert the JavaScript code into the HTML content
    //htmlContent = htmlContent.Replace("</head>", $"{javascriptCode}</head>");

    // Return the HTML file
    // return Results.Content(htmlContent, "text/html")l

    return Results.File(filePath, "text/html");
});

app.MapGet("/api/ad/{width}/{height}", (int width, int height) =>
{
    var imageUrl = CustomerMarketingAlgorithm();

    // Prepare the HTML response with an image (and id temporarily for testing purposes)
    var htmlResponse = $"<a href=\"{imageUrl}\"><img src=\"{imageUrl}\" alt=\"Ad Image\" width=\"{width}\" height=\"{height}\"></a>";

    // Return the HTML response
    return Results.Redirect(imageUrl);
});

app.MapGet("/ad/clicked/{id}", (int id) =>
{
    // var productName = getProductNameFunction(id);
    //var pageURL = "/api/" + productName;

    //call function to add click to stat

    // Return the Product Page response
    //return Results.Redirect(pageURL);
});

app.MapPost("/api/parsejson", async (HttpContext context) =>
{
    using (StreamReader reader = new StreamReader(context.Request.Body))
    {
        var json = await reader.ReadToEndAsync();

        //Parse the JSON to JsonDocument
        using (JsonDocument doc = JsonDocument.Parse(json))
        {
            // Detect the root element type
            JsonElement root = doc.RootElement;

            // Dynamically determine the model based on the root element's properties
            if (root.TryGetProperty("Id", out _))
            {
                // Deserialize to Product model
                var product = JsonSerializer.Deserialize<Product>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Process the product data as needed

                return Results.Text($"Received product: {product.Name}");
            }
            else if (root.TryGetProperty("SomeOtherProperty", out _))
            {
                // Deserialize to another model
                var cart = JsonSerializer.Deserialize<Cart>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Process the other model data as needed

                return Results.Text($"Received data: {cart.Id}");
            }
            else if (root.TryGetProperty("SomeOtherProperty", out _))
            {
                // Deserialize to another model
                var user = JsonSerializer.Deserialize<User>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Process the other model data as needed

                return Results.Text($"Received data: {user.Name}");
            }
            else if (root.TryGetProperty("SomeOtherProperty", out _))
            {
                // Deserialize to another model
                var category = JsonSerializer.Deserialize<Category>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Process the other model data as needed

                return Results.Text($"Received data: {category.Name}");
            }
            else if (root.TryGetProperty("SomeOtherProperty", out _))
            {
                // Deserialize to another model
                var cartProduct = JsonSerializer.Deserialize<Cart_Product>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                // Process the other model data as needed

                return Results.Text($"Received data: {cartProduct.cart_id}");
            }
            else
            {
                // Handle unrecognized JSON structure
                return Results.BadRequest("Unrecognized JSON structure");
            }
        }
    }
});

app.Run();

// this would be the path the code takes if the customer user id is provided
static string CustomerMarketingAlgorithm()
{
    Console.WriteLine("CustomerMarketingAlgorithm called");

    // the image url would be a dynamic image src gathered from the algorithm (and database if required) returning the correct image for the ad spot
    var imageUrl = "https://picsum.photos/650/250.jpg";
    return imageUrl;
}