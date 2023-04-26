using MongoBookStore.Core;
using MongoBookStore.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IBookService,  BookService>();
builder.Services.Configure<BookstoreDbConfig>(builder.Configuration.GetSection(nameof(BookstoreDbConfig)));
builder.Services.AddSingleton<IDbClient, DbClient>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
