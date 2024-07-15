using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IUserRepository
{
    void Update(AppUser user);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser?> GetUserById(int id);
    Task<AppUser?> GetUserByUserameAsync(string username);
    Task<MemberDto?> GetMemberByIdAsync(int id);
    Task<MemberDto?> GetMemberByUsernameAsync(string username);
    Task<IEnumerable<MemberDto>> GetMembersAsync();

}