﻿using System.ComponentModel.DataAnnotations;

namespace MovieApp.Web.ViewModels;

public class MovieEditViewModel
{
    public required int Id { get; set; }
    [Required(ErrorMessage = "Title is Required")]
    [Display(Name = "Title", Prompt = "Enter Movie Title")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "Genre is Required")]
    [Display(Name = "Genre", Prompt = "Enter Movie Genre")]
    public required string Genre { get; set; }

    [Required(ErrorMessage = "Poster Identifier is Required")]
    [Display(Name = "Poster Identifier", Prompt = "Enter Poster Identifier")]
    public required string PosterIdentifier { get; set; }

    [Required(ErrorMessage = "Video Identifier is Required")]
    [Display(Name = "Video Identifier", Prompt = "Enter Video Identifier")]
    public required string VideoIdentifier { get; set; }

    [Required(ErrorMessage = "Release Year is Required")]
    [Display(Name = "Release Year", Prompt = "Enter Release Year")]
    [Range(1900, 2100, ErrorMessage = "Release Year must be between 1900 and 2100")]
    public required int ReleaseYear { get; set; }
}
