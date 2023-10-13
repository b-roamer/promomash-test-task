namespace Application.Provinces.Models;

public class CreateProvinceRequest
{
    public string Name { get; set; }

    public Guid CountryId { get; set; }
}