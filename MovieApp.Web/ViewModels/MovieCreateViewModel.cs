using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.ViewModels;

public class MovieCreateViewModel
{
    [Required(ErrorMessage = "Title is Required")]
    [Display(Name = "Title", Prompt = "Enter Movie Title")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Genre is Required")]
    [Display(Name = "Genre", Prompt = "Enter Movie Genre")]
    public string Genre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Poster Identifier is Required")]
    [Display(Name = "Poster Identifier", Prompt = "Enter Poster Identifier")]
    public string PosterIdentifier { get; set; } = string.Empty;

    [Required(ErrorMessage = "Video Identifier is Required")]
    [Display(Name = "Video Identifier", Prompt = "Enter Video Identifier")]
    public string VideoIdentifier { get; set; } = string.Empty;

    [Required(ErrorMessage = "Release Year is Required")]
    [Display(Name = "Release Year", Prompt = "Enter Release Year")]
    [Range(1900, 2100, ErrorMessage = "Release Year must be between 1900 and 2100")]
    public int ReleaseYear { get; set; }
}
