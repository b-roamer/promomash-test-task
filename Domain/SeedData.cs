using Domain.Entities;

namespace Domain;

public static class SeedData
{
    public static IEnumerable<Country> Countries = new List<Country>
    {
        new()
        {
            CountryId = Guid.Parse("2EB8FB8B-7C66-4413-B18F-F25E91CA0809"),
            Name = "Kazakhstan"
        },
        new()
        {
            CountryId = Guid.Parse("AA2F72AA-303C-45E5-A744-510E9152D83D"),
            Name = "USA"
        }
    };

    public static IEnumerable<Province> Provinces = new List<Province>
    {
        new()
        {
            ProvinceId = Guid.Parse("0E277EBA-E766-4BD4-996F-EC4624603F47"),
            Name = "Almaty",
            CountryId = Guid.Parse("2EB8FB8B-7C66-4413-B18F-F25E91CA0809")
        },
        new()
        {
            ProvinceId = Guid.Parse("537D09AB-9615-41F4-B4C8-BC4FEE49C452"),
            Name = "Astana",
            CountryId = Guid.Parse("2EB8FB8B-7C66-4413-B18F-F25E91CA0809")
        },
        new()
        {
            ProvinceId = Guid.Parse("E56FF022-A741-4545-8132-BC30206B310C"),
            Name = "New York",
            CountryId = Guid.Parse("AA2F72AA-303C-45E5-A744-510E9152D83D")
        },
        new()
        {
            ProvinceId = Guid.Parse("133D9A2D-CEE2-4629-BC13-7CAB76AE68FF"),
            Name = "Washington",
            CountryId = Guid.Parse("AA2F72AA-303C-45E5-A744-510E9152D83D")
        }
    };
}