﻿
namespace DemoNajotEdu.Infrastructure.Abstractions
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string username, string password);
    }
}
