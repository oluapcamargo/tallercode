using CodeInterview.Application.Services.Interfaces;
using CodeInterview.Domain.DTO;
using CodeInterview.Domain.Entity;
using CodeInterview.Infra.Repositories;

namespace CodeInterview.Application.Services;

public class UsersServices : IUsersServices
{
    public readonly UsersRepository _usersRepository;

    public UsersServices(UsersRepository usersRepository)
    {
        _usersRepository = usersRepository;

    }

    public async Task<UsersResponse> GetUserById(Guid id)
    {
        var user = await _usersRepository.GetUserByIdAsync(id);
        return new UsersResponse(user.Id.ToString(), user.Name);
    }

    public async Task<List<UsersResponse>> GetUserByName(string name)
    {
        var users = await _usersRepository.GetUsersByNameAsync(name);
        return users.Select(x => new UsersResponse(x.Id.ToString(), x.Name)).ToList();
    }
    public async Task<Guid> AddUser(string userName, DateTime birthdate)
    {
        var newuser = new Users() { BirthDate = birthdate, Name = userName, Id = Guid.NewGuid() };
        await _usersRepository.AddUserAsync(newuser);
        return newuser.Id;
    }
}
