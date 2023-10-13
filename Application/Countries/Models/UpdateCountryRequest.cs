namespace Application.Countries.Models;

public class UpdateCountryRequest
{
    public Guid CountryId { get; set; }

    public string Name { get; set; }
}