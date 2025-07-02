using Newtonsoft.Json;

namespace CinemaBox.Model.MediaInfo.MediaInfo;

public class MediaInfoResult
{
    [JsonProperty("creatingLibrary")]
    public CreatingLibrary? CreatingLibrary { get; set; }

    [JsonProperty("media")]
    public Media? Media { get; set; }
}

public class CreatingLibrary
{
    [JsonProperty("name")]
    public string? Name { get; set; }

    [JsonProperty("version")]
    public string? Version { get; set; }

    [JsonProperty("url")]
    public string? Url { get; set; }
}

public class Media
{
    [JsonProperty("@ref")]
    public string? Ref { get; set; }

    [JsonProperty("track")]
    public  List<Track?>? Tracks { get; set; }
}

public class Track
{
    [JsonProperty("@type")]
    public string? Type { get; set; }

    // Common Fields
    [JsonProperty("UniqueID", NullValueHandling = NullValueHandling.Ignore)]
    public string? UniqueID { get; set; }

    [JsonProperty("ID", NullValueHandling = NullValueHandling.Ignore)]
    public string? ID { get; set; }

    // General Track
    [JsonProperty("VideoCount", NullValueHandling = NullValueHandling.Ignore)]
    public string? VideoCount { get; set; }

    [JsonProperty("AudioCount", NullValueHandling = NullValueHandling.Ignore)]
    public string? AudioCount { get; set; }

    [JsonProperty("TextCount", NullValueHandling = NullValueHandling.Ignore)]
    public string? TextCount { get; set; }

    [JsonProperty("FileExtension", NullValueHandling = NullValueHandling.Ignore)]
    public string? FileExtension { get; set; }

    [JsonProperty("Format", NullValueHandling = NullValueHandling.Ignore)]
    public string? Format { get; set; }

    // Video Track
    [JsonProperty("Format_Profile", NullValueHandling = NullValueHandling.Ignore)]
    public string? FormatProfile { get; set; }

    [JsonProperty("Width", NullValueHandling = NullValueHandling.Ignore)]
    public string? Width { get; set; }

    [JsonProperty("Height", NullValueHandling = NullValueHandling.Ignore)]
    public string? Height { get; set; }

    // Audio Track
    [JsonProperty("Channels", NullValueHandling = NullValueHandling.Ignore)]
    public string? Channels { get; set; }

    [JsonProperty("Language", NullValueHandling = NullValueHandling.Ignore)]
    public string? Language { get; set; }

    // Text Track
    [JsonProperty("Title", NullValueHandling = NullValueHandling.Ignore)]
    public string? Title { get; set; }

    // Advanced Fields
    [JsonProperty("Encoded_Library_Settings", NullValueHandling = NullValueHandling.Ignore)]
    public string? EncodedLibrarySettings { get; set; }

    [JsonProperty("Duration", NullValueHandling = NullValueHandling.Ignore)]
    public string? Duration { get; set; }

    [JsonProperty("BitRate", NullValueHandling = NullValueHandling.Ignore)]
    public string? BitRate { get; set; }
    [JsonProperty("FrameRate", NullValueHandling = NullValueHandling.Ignore)]
    public string? FrameRate { get; set; }
    [JsonProperty("DisplayAspectRatio", NullValueHandling = NullValueHandling.Ignore)]
    public string? DisplayAspectRatio { get; set; }

}