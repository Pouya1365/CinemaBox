using HtmlAgilityPack;

namespace CinemaBox.Utilities.Loader;
public static class HtmlLoader
{
    public static async Task<HtmlDocument?> LoadDocumentAsync(string url,int i=0)
    {
     
        HtmlWeb web = new();
		try
		{
            return await web.LoadFromWebAsync(url);
        }
		catch (Exception )
		{
            if (i >= 3)
                return null;
         return   await LoadDocumentAsync(url, i++);


        }
      
    }
}