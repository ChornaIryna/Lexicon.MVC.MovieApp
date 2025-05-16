namespace MovieApp.Web.ViewModels;

public class MovieDetailsViewModel
{
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string PosterIdentifier { get; set; } = string.Empty;
    public string VideoIdentifier { get; set; } = string.Empty;
    public int ReleaseYear { get; set; }
}
