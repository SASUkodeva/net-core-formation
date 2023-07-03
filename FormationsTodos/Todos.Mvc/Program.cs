using Microsoft.Extensions.Options;
using Todos.Mvc.Options;
using Todos.Infrastructure.CoreDi;
using Todos.Application.ApplicationDI;
var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("config.json", true);
builder.Configuration.AddEnvironmentVariables();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.Configure<OptionsModel>(builder.Configuration.GetSection("Config"));
builder.Services.AddTodosInfrastructureServices(builder.Configuration);
builder.Services.AddTodosApplicationServices();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



    var config = app.Services.GetService(typeof(IOptions<OptionsModel>)) as IOptions<OptionsModel>;

Console.WriteLine(config.Value.Title);

Console.WriteLine(app.Configuration["Config:Categorie"]); 

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.MapRazorPages();


app.Run();
