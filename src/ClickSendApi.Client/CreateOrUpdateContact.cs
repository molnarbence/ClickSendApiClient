using System.Text.Json.Serialization;

namespace ClickSendApi.Client;

public class CreateOrUpdateContact
{
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = string.Empty;
    [JsonPropertyName("last_name")]
    public string LastName { get; set; } = string.Empty;
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;
    [JsonPropertyName("custom_1")]
    public string Custom1 { get; set; } = string.Empty;
}