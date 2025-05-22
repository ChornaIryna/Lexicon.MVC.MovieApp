namespace MovieApp.Web.ViewModels;

public class MovieListViewModel
{
    public MovieViewModel[] Movies { get; set; } = [];
}

public class MovieViewModel
{
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public required string PosterIdentifier { get; set; }
    public required string VideoIdentifier { get; set; }
    public required int ReleaseYear { get; set; }
    public required int Id { get; set; }
}