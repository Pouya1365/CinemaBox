using CinemaBox.Enumeration.Entertainment.Crew;
using CinemaBox.Model.Entertainment.Cast.Credit;
using CinemaBox.Model.Entertainment.Movie.Movie;
using CinemaBox.Scrapping.Interface.Imdb.MovieExtractors;
using CinemaBox.Utilities.Html;
using HtmlAgilityPack;

namespace CinemaBox.Scrapping.Imdb.MovieExtractors;

public class OtherCrewsExtractor : IOtherCrewsExtractor
{
    public MovieModelScrapping Extract(MovieModelScrapping model, HtmlDocument document)
    {
        var liNodes = document.DocumentNode.SelectNodes("//div[@data-testid='sub-section-cast']//ul//li");
        if (liNodes != null)
        {
            foreach (var li in liNodes)
            {
                var actor = new CreditModel();

                // بازیابی نام بازیگر
                var nameNode = li.SelectSingleNode(".//a[contains(@class, 'name-credits--title-text')]");
                actor.EnFullName = nameNode?.InnerText.Trim();

                // لینک بازیگر → شامل شناسه nm
                var actorLinkNode = li.SelectSingleNode(".//a[contains(@href,'/name/nm')]");
                var actorHref = actorLinkNode?.GetAttributeValue("href", "");
                if (!string.IsNullOrEmpty(actorHref))
                {
                    var parts = actorHref.Split('/');
                    if (parts.Length > 2)
                        actor.ImdbId = parts[2]; // مثلا nm0011148
                }

                // نام نقش
                var roleNode = li.SelectSingleNode(".//a[contains(@href,'/characters/')]");
                actor.Role = HtmlDecode.HtmlDecoding(roleNode?.InnerText.Trim());

                // عکس بازیگر
                var imgNode = li.SelectSingleNode(".//img[contains(@class,'ipc-image')]");
                actor.ImageUrl = imgNode?.GetAttributeValue("src", "");
                actor.MovieId = model.ImdbId;
                actor.CreditType = CreditEnumeration.Cast.ToString();
                if (!model.Credits.Any(x => x.ImdbId == actor.ImdbId))
                    model.Credits.Add(actor);
            }

        }
        return model;
    }
}
