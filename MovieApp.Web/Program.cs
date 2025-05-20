var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<MovieApp.Web.Interfaces.IMovieService, MovieApp.Web.Services.MovieService>();
var app = builder.Build();

app.MapControllers();
app.UseStaticFiles();

app.Run();
