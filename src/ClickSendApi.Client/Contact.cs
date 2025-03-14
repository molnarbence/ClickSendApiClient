using System.Text.Json.Serialization;

namespace ClickSendApi.Client;

public class Contact : CreateOrUpdateContact
{
    [JsonPropertyName("contact_id")] 
    public int ContactId { get; set; }
    [JsonPropertyName("list_id")]    
    public int ListId { get; set; }    
}