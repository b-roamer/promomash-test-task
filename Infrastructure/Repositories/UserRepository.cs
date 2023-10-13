using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DatabaseContext _context;

    public UserRepository(DatabaseContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Find user by its ID
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>User</returns>
    /// <exception cref="EntityNotFoundException"></exception>
    public async Task<User> GetById(Guid userId)
    {
        return await _context.Users.FindAsync(userId)
               ?? throw new EntityNotFoundException("User does not exist.");
    }

    /// <summary>
    ///     Get all users
    /// </summary>
    /// <returns>List of users</returns>
    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    /// <summary>
    ///     Insert a new user
    /// </summary>
    /// <param name="user"></param>
    /// <returns>Inserted user</returns>
    /// <exception cref="DuplicateValueException"></exception>
    public async Task<User> Insert(User user)
    {
        if (_context.Users.Any(x => x.Email.ToLower() == user.Email.ToLower()))
            throw new DuplicateValueException($"User with the email [{user.Email}] already exists.");

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    /// <summary>
    ///     Update existing user
    /// </summary>
    /// <param name="user"></param>
    /// <returns>Updated user</returns>
    /// <exception cref="EntityNotFoundException"></exception>
    /// <exception cref="DuplicateValueException"></exception>
    public async Task<User> Update(User user)
    {
        var existingEntity = await _context.Users.FindAsync(user.UserId)
                             ?? throw new EntityNotFoundException("User does not exist.");

        if (_context.Users.Any(x => x.Email.ToLower() == user.Email.ToLower()))
            throw new DuplicateValueException($"User with the email [{user.Email}] already exists.");

        existingEntity.Email = user.Email;
        existingEntity.CountryId = user.CountryId;
        existingEntity.ProvinceId = user.ProvinceId;
        existingEntity.UpdatedDate = DateTime.UtcNow;

        await _context.SaveChangesAsync();
        return existingEntity;
    }

    /// <summary>
    ///     Deletes user
    /// </summary>
    /// <param name="userId"></param>
    /// <exception cref="EntityNotFoundException"></exception>
    public async Task Delete(Guid userId)
    {
        var user = await _context.Users.FindAsync(userId)
                   ?? throw new EntityNotFoundException("User does not exist.");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetUserByEmail(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower())
                   ?? throw new EntityNotFoundException("User does not exist.");

        return user;
    }
}