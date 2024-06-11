using EFreelancer.Models.Global;
using EFreelancer.Models.Traders;

namespace EFreelancer.Services
{
    public interface IIdentityService
    {
        Task<UserEntityCreationResult> CreateTraderUser(CreateTraderUserData data);
    }
}
