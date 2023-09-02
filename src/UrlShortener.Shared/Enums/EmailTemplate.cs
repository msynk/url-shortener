namespace UrlShortener.Shared.Enums;

[JsonConverter(typeof(JsonStringEnumConverter<EmailTemplate>))]
public enum EmailTemplate
{
    EmailChange,
    EmailConfirmation
}
