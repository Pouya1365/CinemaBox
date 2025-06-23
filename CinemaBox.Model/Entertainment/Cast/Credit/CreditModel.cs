namespace CinemaBox.Model.Entertainment.Cast.Credit;

public class CreditModel
{
    public string? CreditType { get; set; }
    public string? EnFullName { get; set; }
    public string? ImdbId { get; set; }
    public string? Role { get; set; }
    public string? ImageUrl { get; set; }
    public string? MovieId { get; set; }
    public bool? IsLead { get; set; }
}
