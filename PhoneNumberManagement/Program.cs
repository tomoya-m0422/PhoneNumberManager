using Microsoft.Extensions.FileProviders;
using PhoneNumberManagement.Controllers;
using PhoneNumberManagement.Services;
//’Ç‰Á‚µ‚½
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

//’Ç‰Á‚µ‚½
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          //policy.WithOrigins("http://localhost:5500",
                          //                    "https://localhost:5501",
                          //                    "http://localhost:7297",
                          //                    "http://127.0.0.1:5501")
                          policy.WithOrigins("*")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});
// Add services to the container.
builder.Services.AddRazorPages();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//‚±‚Á‚©‚ç
app.MapGet("/h", () => "Hello World!");
app.MapGet("/a", () => "Hello World!");
app.UseStaticFiles();
//Console.WriteLine("Hello");
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(
//        Path.Combine(Directory.GetCurrentDirectory(), "Test")),
//    RequestPath = "/Test"
//});
app.UseCors(MyAllowSpecificOrigins);
//‚±‚±‚Ü‚Å

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
//app.MapRazorPages();
//
app.UseDefaultFiles();
app.MapControllers();
//
app.Run();