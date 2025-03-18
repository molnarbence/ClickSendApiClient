using Refit;
using System.Text.Json.Serialization;

namespace ClickSendApi.Client;

[Headers("Authentication: Basic")]
public interface IClickSendApi
{
    [Get("/lists/{contactListId}/contacts")]
    Task<GetContactsByContactListIdResponse> GetContactsByContactListIdAsync(int contactListId, [AliasAs("page")] int page, [AliasAs("limit")] int limit);

    [Post("/lists/{contactListId}/contacts")]
    Task<IApiResponse<CreateContactResponse>> AddContactToContactList(int contactListId, [Body] CreateOrUpdateContact contact);

    [Put("/lists/{contactListId}/contacts/{contactId}")]
    Task<IApiResponse<UpdateContactResponse>> UpdateContact(int contactListId, int contactId, [Body] CreateOrUpdateContact contact);

    [Delete("/lists/{contactListId}/contacts/{contactId}")]
    Task<IApiResponse> DeleteContactFromContactList(int contactListId, int contactId);
}


public class GetContactsByContactListIdResponse : ClickSendApiPagedResponse<Contact>
{
}

public class CreateContactResponse : ClickSendApiResponse<Contact>
{
}

public class UpdateContactResponse : ClickSendApiResponse<Contact>
{
}

public class ClickSendApiResponse<T>
{
    [JsonPropertyName("data")]
    public required T Data { get; set; }
}

public class ClickSendApiPagedResponse<T>
{
    [JsonPropertyName("data")]
    public required ClickSendApiPagedResponseData<T> Data { get; set; }
}