namespace Domain.Entities;

public class Country : EntityBase
{
    public Guid CountryId { get; set; }

    public string Name { get; set; }

    public IEnumerable<Province> Provinces { get; } = new List<Province>();
}