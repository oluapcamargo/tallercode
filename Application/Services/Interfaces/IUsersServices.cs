using CodeInterview.Domain.DTO;

namespace CodeInterview.Application.Services.Interfaces;

public interface IUsersServices
{
    Task<List<UsersResponse>> GetUserByName(string name);
    Task<UsersResponse> GetUserById(Guid id);
    Task<Guid> AddUser(string userName, DateTime birthdate);

}
