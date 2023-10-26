using DemoNajotEdu.Domain.Entities;
using DemoNajotEdu.Infrastructure.Abstractions;
using DemoNajotEdu.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using DemoNajotEdu.Application.Abstractions;

namespace DemoNajotEdu.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbcontext _dbcontext;

        private readonly ITokenService _tokenService;
        private readonly IHashProvider _hashProvider;

        public AuthService(ApplicationDbcontext dbContext, ITokenService tokenService,IHashProvider hashProvider)
        {
            _dbcontext = dbContext;
            _tokenService = tokenService;
            _hashProvider = hashProvider;
        }
        public async Task<string> LoginAsync(string userName, string password)
        {
            var user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.UserName == userName);

            if (user == null)
            {
                throw new Exception("User Not found");
            }
            else if (user.PasswordHash != _hashProvider.GetHash(password))
            {
                throw new Exception("Password is wrong");
            }
            return _tokenService.GenerateAccessToken(user);
        }
    }
}
