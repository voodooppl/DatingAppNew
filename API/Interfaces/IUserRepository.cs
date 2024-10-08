using API.DTOs;
using API.Entities;
using API.Helpers;

namespace API.Interfaces;

public interface IUserRepository
{
    void Update(AppUser user);
    public Task<AppUser?> GetUserByPhotoId(int photoId);
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser?> GetUserByIdAsync(int id);
    Task<AppUser?> GetUserByUserameAsync(string username);
    // Task<MemberDto?> GetMemberByIdAsync(int id);
    Task<MemberDto?> GetMemberByUsernameAsync(string username, bool isCurrentUser);
    Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);

}