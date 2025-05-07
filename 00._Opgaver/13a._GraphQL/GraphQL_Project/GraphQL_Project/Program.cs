using GraphQL_API.Context;
using GraphQL_ClassLibrary.Models;
using GraphQL_Project.Repositories;
using GraphQL_Project.Types;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<SampleDBContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SampleDb")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddGraphQLServer()
    .RegisterDbContextFactory<SampleDBContext>()
    .AddGraphQL_APITypes()
    .AddType<ErrorMessage>()
    .AddProjections()
    .AddFiltering()
    .AddSorting()
    .AddInMemorySubscriptions();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

var app = builder.Build();

app.UseRouting();

app.UseCors("AllowAllOrigins");

app.UseWebSockets();

app.MapGraphQL();

app.Run();
