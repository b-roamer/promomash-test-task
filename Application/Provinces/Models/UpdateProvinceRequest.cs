namespace Application.Provinces.Models;

public class UpdateProvinceRequest
{
    public Guid ProvinceId { get; set; }

    public Guid CountryId { get; set; }

    public string Name { get; set; }
}