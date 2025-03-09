using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add CORS services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClientApp", policy =>
    {
        policy.WithOrigins("http://localhost:5274")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

//Add memory cache services
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Use CORS middleware
app.UseCors("AllowClientApp");

//Add response caching middleware
app.UseResponseCaching();

// Add cache headers middleware
app.Use(async (context, next) =>
{
    // Set cache-control headers for all responses
    context.Response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue
    {
        Public = true,
        MaxAge = TimeSpan.FromSeconds(300) // Cache for 5 minutes
    };
    await next();
});

app.UseHttpsRedirection();

// Products cache key
const string PRODUCTS_CACHE_KEY = "products_data";

app.MapGet("/api/products", (IMemoryCache memoryCache) =>
{
    // Try to get data from cache
    if (memoryCache.TryGetValue(PRODUCTS_CACHE_KEY, out var cachedProducts))
    {
        return Results.Ok(cachedProducts);
    }

    var products = new[]
    {
        new { Id = 1, Name = "Laptop", Price = 1200.50, Stock = 25, Category = new { Id = 1, Name = "Electronics" } },
        new { Id = 2, Name = "Headphones", Price = 50.00, Stock = 100, Category = new { Id = 1, Name = "Electronics" } },
        new { Id = 3, Name = "Smartphone", Price = 700.00, Stock = 50, Category = new { Id = 2, Name = "Electronics" } },
        new { Id = 4, Name = "Tablet", Price = 250.00, Stock = 35, Category = new { Id = 2, Name = "Electronics" } },
        new { Id = 5, Name = "Smartwatch", Price = 120.00, Stock = 15, Category = new { Id = 3, Name = "Wearables" } },
        new { Id = 6, Name = "Keyboard", Price = 35.00, Stock = 50, Category = new { Id = 4, Name = "Accessories" } },


    };

    // Cache options - set absolute expiration time
    var cacheEntryOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(10))
        .SetSlidingExpiration(TimeSpan.FromMinutes(2))
        .SetPriority(CacheItemPriority.High);

    // Save data in cache
    memoryCache.Set(PRODUCTS_CACHE_KEY, products, cacheEntryOptions);

    return Results.Ok(products);
})
.WithName("GetProducts")
.WithOpenApi()
.CacheOutput(builder => builder.Expire(TimeSpan.FromMinutes(5)));

app.Run();
