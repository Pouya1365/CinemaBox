namespace CinemaBox.Libretranslate.Interface;

public interface ITranslate
{
    Task<string> TranslateText(string text);
}
