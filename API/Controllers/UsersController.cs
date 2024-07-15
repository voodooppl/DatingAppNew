using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository userRepository) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsersAsync()
    {
        var users = await userRepository.GetMembersAsync();

        return Ok(users);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<MemberDto>> GetUserById(int id)
    {
        var user = await userRepository.GetMemberByIdAsync(id);

        if (user == null) return NotFound();

        return user;
    }

    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUserByUsername(string username)
    {
        var user = await userRepository.GetMemberByUsernameAsync(username);

        if (user == null) return NotFound();

        return user;
    }
}
