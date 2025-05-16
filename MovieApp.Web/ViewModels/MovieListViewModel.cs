using MovieApp.Web.Models;

namespace MovieApp.Web.ViewModels;

public class MovieListViewModel
{
    public List<Movie> Movies { get; set; } = new();
}
