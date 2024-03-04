using System.Text.Json.Serialization;
namespace Assignment02.Models;

public class TvShow
{
    [JsonPropertyName("id")]
    public int Id {get; set;}
    
    [JsonPropertyName("backdrop_path")]
    public string? BackdropPath {get; set;}

    [JsonPropertyName("name")]
    public string? Name {get; set;}

    [JsonPropertyName("origin_country")]
    public string? OriginCountry {get; set;}

    [JsonPropertyName("original_language")]
    public string? OriginalLanguage {get; set;}

    [JsonPropertyName("original_name")]
    public string? OriginalName {get; set;}

    [JsonPropertyName("overview")]
    public string? Overview {get; set;}

    [JsonPropertyName("popularity")]
    public double Popularity {get; set;}

    [JsonPropertyName("poster_path")]
    public string? PosterPath {get; set;}

    [JsonPropertyName("vote_average")]
    public double VoteAverage {get; set;}

    [JsonPropertyName("vote_count")]
    public int VoteCount {get; set;}
}

