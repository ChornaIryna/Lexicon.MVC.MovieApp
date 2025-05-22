namespace MovieApp.Web.ViewModels;

public class MovieDetailsViewModel
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public required string PosterIdentifier { get; set; }
    public required string VideoIdentifier { get; set; }
    public required int ReleaseYear { get; set; }
}
