using CinemaBox.Enumeration.Entertainment.Crew;
using CinemaBox.Model.Entertainment.Cast.Credit;
using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Download;
using CinemaBox.Utilities.Html;
using HtmlAgilityPack;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class OtherCrewsExtractor : IOtherCrewsExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, HtmlDocument document)
    {
        HtmlNodeCollection? liNodes = document.DocumentNode.SelectNodes("//div[@data-testid='sub-section-cast']//ul//li");
        if (liNodes != null)
        {
            foreach (HtmlNode li in liNodes)
            {
                CreditModel actor = new();

                // بازیابی نام بازیگر
                HtmlNode? nameNode = li.SelectSingleNode(".//a[contains(@class, 'name-credits--title-text')]");
                actor.EnFullName = nameNode?.InnerText.Trim();

                // لینک بازیگر → شامل شناسه nm
                HtmlNode? actorLinkNode = li.SelectSingleNode(".//a[contains(@href,'/name/nm')]");
                string? actorHref = actorLinkNode?.GetAttributeValue("href", "");
                if (!string.IsNullOrEmpty(actorHref))
                {
                    string[] parts = actorHref.Split('/');
                    if (parts.Length > 2)
                        actor.ImdbId = parts[2]; // مثلا nm0011148
                }

                // نام نقش
                HtmlNode? roleNode = li.SelectSingleNode(".//a[contains(@href,'/characters/')]");
                actor.Role = HtmlDecode.HtmlDecoding(roleNode?.InnerText.Trim());

                // عکس بازیگر
                HtmlNode? imgNode = li.SelectSingleNode(".//img[contains(@class,'ipc-image')]");
                actor.ImageUrl = ImageExtension.CleanImageUrl( imgNode?.GetAttributeValue("src", ""));
                actor.MovieId = model.ImdbId;
                actor.CreditType = CreditEnumeration.Cast.ToString();
                if (!model.Credits.Any(x => x.ImdbId == actor.ImdbId))
                    model.Credits.Add(actor);
            }

        }
        return model;
    }
}
