namespace ClickSendApi.Client;

internal class ClickSendConfig
{
    internal const string SectionName = "ClickSend";

    public string Username { get; init; } = null!;
    public string ApiKey { get; init; } = null!;
}
