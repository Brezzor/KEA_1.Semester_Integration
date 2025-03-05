var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/json", async () =>
{
    Me? me = await FileReader.ReadJsonFile();
    return me;
});

app.MapGet("/xml", () =>
{
    Me? me = FileReader.ReadXMLFile();
    return me;
});

app.MapGet("/csv", async () =>
{
    Me? me = await FileReader.ReadCSVFile();
    return me;
});

app.MapGet("/yaml", () =>
{
    Me? me = FileReader.ReadYAMLFile();
    return me;
});

app.MapGet("/txt", () =>
{
    Me? me = FileReader.ReadTXTFile();
    return me;
});

app.MapGet("/jsonFromNode", async () =>
{
    using (HttpClient httpClient = new HttpClient())
    {
        return await httpClient.GetFromJsonAsync<MeResponse>("Http://localhost:8080/json");
    }
});

app.MapGet("/xmlFromNode", async () =>
{
    using (HttpClient httpClient = new HttpClient())
    {
        return await httpClient.GetFromJsonAsync<MeResponse>("Http://localhost:8080/xml");
    }
});

app.MapGet("/csvFromNode", async () =>
{
    using (HttpClient httpClient = new HttpClient())
    {
        return await httpClient.GetFromJsonAsync<MeResponse>("Http://localhost:8080/csv");
    }
});

app.MapGet("/yamlFromNode", async () =>
{
    using (HttpClient httpClient = new HttpClient())
    {
        return await httpClient.GetFromJsonAsync<MeResponse>("Http://localhost:8080/yaml");
    }
});

app.MapGet("/txtFromNode", async () =>
{
    using (HttpClient httpClient = new HttpClient())
    {
        return await httpClient.GetFromJsonAsync<MeResponse>("Http://localhost:8080/txt");
    }
});

app.Run();
