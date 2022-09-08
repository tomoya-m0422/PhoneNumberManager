using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
            builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins(new string[] { "http://localhost:4200" })
    );

    options.AddPolicy("CorsPolicyName", 
        builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins(new string[] { "https://localhost:7059" }));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
/*
 if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
    await next();
});


app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

#region ’Ç‰Á
app.UseDefaultFiles();

app.UseStaticFiles();
/*
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "WebClient")),
    RequestPath = "/WebClient"
});
*/
#endregion

app.Run();
