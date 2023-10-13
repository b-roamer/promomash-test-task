using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProvinceRepository : IProvinceRepository
{
    private readonly DatabaseContext _context;

    public ProvinceRepository(DatabaseContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Find province by its ID
    /// </summary>
    /// <param name="provinceId"></param>
    /// <returns>Province</returns>
    /// <exception cref="EntityNotFoundException"></exception>
    public async Task<Province> GetById(Guid provinceId)
    {
        return await _context.Provinces.FindAsync(provinceId)
               ?? throw new EntityNotFoundException("Province does not exist.");
    }

    /// <summary>
    ///     Get all provinces
    /// </summary>
    /// <returns>List of provinces</returns>
    public async Task<IEnumerable<Province>> GetAll()
    {
        return await _context.Provinces.ToListAsync();
    }

    /// <summary>
    ///     Insert a new province
    /// </summary>
    /// <param name="province"></param>
    /// <returns>Inserted province</returns>
    /// <exception cref="DuplicateValueException"></exception>
    public async Task<Province> Insert(Province province)
    {
        if (_context.Provinces.Any(x => x.Name.ToLower() == province.Name.ToLower()))
            throw new DuplicateValueException($"Province with the name [{province.Name}] already exists.");

        await _context.Provinces.AddAsync(province);
        await _context.SaveChangesAsync();

        return province;
    }

    /// <summary>
    ///     Update existing province
    /// </summary>
    /// <param name="province"></param>
    /// <returns>Updated province</returns>
    /// <exception cref="EntityNotFoundException"></exception>
    /// <exception cref="DuplicateValueException"></exception>
    public async Task<Province> Update(Province province)
    {
        var existingEntity = await _context.Provinces.FindAsync(province.ProvinceId)
                             ?? throw new EntityNotFoundException("Province does not exist.");

        if (_context.Provinces.Any(x => x.Name.ToLower() == province.Name.ToLower()))
            throw new DuplicateValueException($"Province with the name [{province.Name}] already exists.");

        existingEntity.Name = province.Name;
        existingEntity.CountryId = province.CountryId;
        existingEntity.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return existingEntity;
    }

    /// <summary>
    ///     Deletes province
    /// </summary>
    /// <param name="provinceId"></param>
    /// <exception cref="EntityNotFoundException"></exception>
    public async Task Delete(Guid provinceId)
    {
        var province = await _context.Provinces.FindAsync(provinceId)
                       ?? throw new EntityNotFoundException("Province does not exist.");

        _context.Provinces.Remove(province);
        await _context.SaveChangesAsync();
    }
}