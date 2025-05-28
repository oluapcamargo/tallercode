using CodeInterview.Application.Services.Interfaces;
using CodeInterview.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CodeInterview.Controllers
{
    [ApiController]
    [Route("")]
    public class CodeSnippetController : ControllerBase
    {
        private readonly ILogger<CodeSnippetController> _logger;
        private readonly IUsersServices _usersServices;

        public CodeSnippetController(ILogger<CodeSnippetController> logger, IUsersServices usersServices)
        {
            _logger = logger;
            _usersServices = usersServices;
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        [HttpGet("byname")]
        public async Task<List<UsersResponse>> GetUserByName(string name)
        {
            return await _usersServices.GetUserByName(name);
        }
        [HttpGet("byid")]
        public async Task<UsersResponse> GetUserById(string id)
        {
            return await _usersServices.GetUserById(Guid.Parse(id));
        }
        [HttpPost]
        public async Task<Guid> GetUserById([FromBody] UsersAddRequest request)
        {
            return await _usersServices.AddUser(request.UserName, request.BirthDate);
        }
    }
}
