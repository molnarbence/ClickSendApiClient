using System.Text.Json.Serialization;

namespace ClickSendApi.Client;

public class ClickSendApiPagedResponseData<T>
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }

    [JsonPropertyName("current_page")]
    public int CurrentPage { get; set; }

    [JsonPropertyName("last_page")]
    public int LastPage { get; set; }

    [JsonPropertyName("data")]
    public required IEnumerable<T> Data { get; set; }
}