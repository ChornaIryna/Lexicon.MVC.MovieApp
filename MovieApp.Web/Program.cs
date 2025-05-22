var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<MovieApp.Web.Interfaces.IMovieService, MovieApp.Web.Services.MovieService>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error/exception");
    app.UseStatusCodePagesWithRedirects("/error/statuscode/{0}");
}

app.MapControllers();
app.UseStaticFiles();

app.Run();
