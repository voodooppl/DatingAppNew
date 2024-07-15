using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UserRepository(DataContext context, IMapper mapper) : IUserRepository
{
    public async Task<MemberDto?> GetMemberByIdAsync(int id)
    {
        return await context.Users
            .Where(u => u.Id == id)
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
    }

    public async Task<MemberDto?> GetMemberByUsernameAsync(string username)
    {
        return await context.Users
            .Where(u => u.UserName == username)
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
    }

    public async Task<IEnumerable<MemberDto>> GetMembersAsync()
    {
        return await context.Users
            .ProjectTo<MemberDto>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<AppUser?> GetUserById(int id)
    {
        return await context.Users
        .Include(u => u.Photos)
            .SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task<AppUser?> GetUserByUserameAsync(string username)
    {
        return await context.Users
            .Include(u => u.Photos)
            .SingleOrDefaultAsync(u => u.UserName == username);

    }

    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
        return await context.Users
            .Include(u => u.Photos)
            .ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void Update(AppUser user)
    {
        context.Entry(user).State = EntityState.Modified;
    }
}
