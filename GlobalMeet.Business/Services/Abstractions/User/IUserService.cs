using GlobalMeet.Business.Dtos.User.Post;
using GlobalMeet.Business.Results;

namespace GlobalMeet.Business.Services.Abstractions.User
{
    public interface IUserService
    {
        Task<ServiceResult> GetUser(int userId);
        Task<ServiceResult> UpdateUser(int userId, UpdateUserDto updateUserDto);
        Task<ServiceResult> Register(RegisterUserDto registerUser);
        Task<ServiceResult> LogIn(LoginUserDto loginUser);
        Task<ServiceResult> LogOut();
        Task<ServiceResult> AddClaim(AddClaimDto claim);
        Task<ServiceResult> GetUsers();
        ServiceResult GetLoggedUser();
        Task<ServiceResult> PasswordResetAsync(string email);
        Task<bool> VerifyResetTokenAsync(string resetToke, string UserName);
        Task<bool> UpdatePassword(string userName, string resetToken, string newPassword);
        Task<bool> EmailConfirmAsync(string email);
        Task<bool> VerifyConfirmAsync(string userName, string confirmToken);

        Task<ServiceResult> GetUserByCompany(int companyId);
    }
}
