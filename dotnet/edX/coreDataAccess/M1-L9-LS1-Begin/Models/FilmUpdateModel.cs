public class FilmUpdateModel
{
    public int FilmId { get;  set; }
    public string Description { get; internal set; }
    public string Title { get; internal set; }
    public int? RatingId { get; internal set; }
    public int? ReleaseYear { get; internal set; }
}
