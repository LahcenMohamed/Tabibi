namespace Tabibi.Domain.Clinics.ValueObjects
{
    public sealed record Address(string State, string City, string Street, string? UrlOnMap);
}
