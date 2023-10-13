using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CountryRepository : ICountryRepository
{
    private readonly DatabaseContext _context;

    public CountryRepository(DatabaseContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Find country by its ID
    /// </summary>
    /// <param name="countryId"></param>
    /// <returns>Country</returns>
    /// <exception cref="EntityNotFoundException"></exception>
    public async Task<Country> GetById(Guid countryId)
    {
        return await _context.Countries
                   .Include(x => x.Provinces)
                   .FirstOrDefaultAsync(x => x.CountryId == countryId)
               ?? throw new EntityNotFoundException("Country does not exist.");
    }

    /// <summary>
    ///     Get all countries
    /// </summary>
    /// <returns>List of countries</returns>
    public async Task<IEnumerable<Country>> GetAll()
    {
        return await _context.Countries
            .Include(x => x.Provinces)
            .ToListAsync();
    }

    /// <summary>
    ///     Insert a new country
    /// </summary>
    /// <param name="country"></param>
    /// <returns>Inserted country</returns>
    /// <exception cref="DuplicateValueException"></exception>
    public async Task<Country> Insert(Country country)
    {
        if (_context.Countries.Any(x => x.Name.ToLower() == country.Name.ToLower()))
            throw new DuplicateValueException($"Country with the name [{country.Name}] already exists.");

        await _context.Countries.AddAsync(country);
        await _context.SaveChangesAsync();

        return country;
    }

    /// <summary>
    ///     Update existing country
    /// </summary>
    /// <param name="country"></param>
    /// <returns>Updated country</returns>
    /// <exception cref="EntityNotFoundException"></exception>
    /// <exception cref="DuplicateValueException"></exception>
    public async Task<Country> Update(Country country)
    {
        var existingEntity = await _context.Countries.FindAsync(country.CountryId)
                             ?? throw new EntityNotFoundException("Country does not exist.");

        if (_context.Countries.Any(x => x.Name.ToLower() == country.Name.ToLower()))
            throw new DuplicateValueException($"Country with the name [{country.Name}] already exists.");

        existingEntity.Name = country.Name;
        existingEntity.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return existingEntity;
    }

    /// <summary>
    ///     Deletes country
    /// </summary>
    /// <param name="countryId"></param>
    /// <exception cref="EntityNotFoundException"></exception>
    public async Task Delete(Guid countryId)
    {
        var country = await _context.Countries.FindAsync(countryId)
                      ?? throw new EntityNotFoundException("Country does not exist.");

        _context.Countries.Remove(country);
        await _context.SaveChangesAsync();
    }
}