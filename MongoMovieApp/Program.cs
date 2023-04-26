using MongoMovieApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.Configure<MovieStoreSettings>(builder.Configuration.GetSection("MovieStoreSettings"));

builder.Services.AddSingleton<MovieService>();


var app = builder.Build();
app.MapGet("/", () => "Mongo Movie App");

app.MapPost("/api/movies", async (MovieService movieService, Movie movie) =>
{
    await movieService.Create(movie);
    return Results.Ok();
});

app.MapGet("/api/movies", async (MovieService movieService) => await movieService.Get());

app.MapGet("/api/movies/{id}", async (MovieService movieService, string id) => {
    var tempMovie = await movieService.Get(id);

    if (tempMovie == null) return Results.NotFound();
    return Results.Ok(tempMovie);
    
});

app.MapPut("/api/movies/{id}", async (MovieService movieService, string id, Movie movie) =>
{
    var tempMovie = movieService.Get(id);

    if (tempMovie == null) return Results.NotFound();
    await movieService.Update(id, movie);
    return Results.Ok(movie);
});

app.MapDelete("/api/movies/{id}", async (MovieService movieService, string id) => await movieService.Remove(id));

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
