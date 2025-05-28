namespace CodeInterview.Domain.DTO;

public class UsersResponse
{
    public string UserId { get; set; }
    public string UserName { get; set; }

    public UsersResponse(string userId, string userName)
    {
        UserId = userId;
        UserName = userName;
    }
}
