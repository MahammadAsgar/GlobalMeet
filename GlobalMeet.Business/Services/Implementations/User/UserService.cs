using AutoMapper;
using GlobalMeet.Business.Dtos.User.Get;
using GlobalMeet.Business.Dtos.User.Post;
using GlobalMeet.Business.Helpers;
using GlobalMeet.Business.Results;
using GlobalMeet.Business.Services.Abstractions.Mail;
using GlobalMeet.Business.Services.Abstractions.User;
using GlobalMeet.DataAccess.Context;
using GlobalMeet.DataAccess.Entities.User;
using GlobalMeet.DataAccess.Models;
using GlobalMeet.DataAccess.UnitOfWorks;
using GlobalMeet.Infrastructure.Extensions;
using GlobalMeet.Infrastructure.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GlobalMeet.Business.Services.Implementations.User
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly GlobalMeetDbContext _dbContext;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISession _session;
        private readonly IMailService _mailService;
        public UserService(UserManager<AppUser> userManager,
                            SignInManager<AppUser> signInManager,
                            IMapper mapper,
                            ITokenHelper tokenHelper,
                            IHttpContextAccessor httpContextAccessor,
                            IUnitOfWork unitOfWork, GlobalMeetDbContext dbContext,
                            IMailService mailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _unitOfWork = unitOfWork;
            _session = httpContextAccessor.HttpContext.Session;
            _dbContext = dbContext;
            _mailService = mailService;
        }
        public async Task<ServiceResult> AddClaim(AddClaimDto addClaim)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(addClaim.UserId);
                var claim = new Claim(addClaim.ClaimType, addClaim.ClaimName);

                if (user == null)
                    return new ServiceResult(false, "user not found");

                var result = await _userManager.AddClaimAsync(user, claim);

                if (result.Succeeded)
                    return new ServiceResult(true, "aded claim successfull");

                return new ServiceResult(false, String.Join(';', result.Errors.Select(x => x.Code)));
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task<bool> EmailConfirmAsync(string email)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            var x = 0;
            if (user != null)
            {
                string confirmToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                confirmToken = confirmToken.UrlEncode();
                await _mailService.SendEmailConfirmMail(email, user.UserName, confirmToken);
                return true;
            }
            return false;
        }

        public ServiceResult GetLoggedUser()
        {
            try
            {
                var userData = _session.GetObject<UserSessionDto>("userdetail");
                if (userData == null)
                    return new ServiceResult(false, "data not found");

                return new ServiceResult(true, userData.Id);
            }
            catch (Exception)
            {
                return new ServiceResult(false, "data not found");
            }
        }

        public async Task<ServiceResult> GetUser(int userId)
        {
            try
            {
                var result = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

                if (result != null)
                {
                    var response = _mapper.Map<AppUserDto>(result);
                    return new ServiceResult(true, response, "user successfully found");
                }

                return new ServiceResult(false, "user not found");
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task<ServiceResult> GetUsers()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();

                if (users != null)
                {
                    var response = _mapper.Map<IEnumerable<AppUser>>(users);
                    return new ServiceResult(true, response);
                }

                return new ServiceResult(false, "user not found");
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task<ServiceResult> LogIn(LoginUserDto loginUser)
        {
            try
            {
                AppUser user = await _userManager.FindByNameAsync(loginUser.UserName);

                if (user == null)
                    return new ServiceResult(false, "usernotfound");

                var result = await _signInManager.PasswordSignInAsync(user, loginUser.Password, true, false);
                var claims = await _userManager.GetClaimsAsync(user);


                var token = _tokenHelper.CreateToken(_mapper.Map<AppUser>(user), claims);
                if (!result.Succeeded)
                {

                    return new ServiceResult(false, "usernotfound");
                }
                if (user.EmailConfirmed == false)
                    return new ServiceResult(true, "emailnotverify");
                var detail = new UserSessionDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    FirstName = user.Name,
                    LastName = user.Surname,
                    Email = user.Email,
                };
                _session.SetObject("userdetail", detail);
                return new ServiceResult(true, token, "login success");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ServiceResult> LogOut()
        {
            try
            {
                await _signInManager.SignOutAsync();

                return new ServiceResult(true, "successfully logout");
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task<ServiceResult> PasswordResetAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                resetToken = resetToken.UrlEncode();
                await _mailService.SendPasswordResetMail(email, user.UserName, resetToken);
                return new ServiceResult(true, "sa");
            }
            else
            {
                return new ServiceResult(false, "emailnotfound");
            }
        }

        public async Task<ServiceResult> Register(RegisterUserDto registerUser)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(registerUser.Email);
                var user1 = await _userManager.FindByNameAsync(registerUser.UserName);
                if (user1 != null)
                {
                    return new ServiceResult(false, "username alreadyused");
                }
                if (user != null)
                    return new ServiceResult(false, "email alreadyused");
                var requestData = _mapper.Map<AppUser>(registerUser);
                IdentityResult result = await _userManager.CreateAsync(requestData, registerUser.Password);

                if (result.Succeeded)
                {
                    return new ServiceResult(true, "registration completed");
                }
                return new ServiceResult(false, String.Join(';', result.Errors.Select(x => x.Code)));
            }
            catch (Exception ex)
            {
                return new ServiceResult(false, ex.Message);
            }
        }

        public async Task<bool> UpdatePassword(string userName, string resetToken, string newPassword)
        {

            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                resetToken = resetToken.UrlDecode();
                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }



        public async Task<bool> VerifyConfirmAsync(string userName, string confirmToken)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                confirmToken = confirmToken.UrlDecode();
                var result = await _userManager.ConfirmEmailAsync(user, confirmToken);
                if (result.Succeeded)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> VerifyResetTokenAsync(string resetToken, string UserName)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            if (user != null)
            {
                resetToken = resetToken.UrlDecode();
                return await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetToken);
            }
            return false;
        }


        //Admin
        public async Task<ServiceResult> UpdateUser(int userId, UpdateUserDto updateUserDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);
            if (user != null)
            {
                //if (updateUserDto.AboutId.HasValue)
                //{
                //    user.AboutId = updateUserDto.AboutId.Value;
                //}

                //if (updateUserDto.Experience.HasValue)
                //{
                //    user.Experience = updateUserDto.Experience.Value;
                //}

                //if (updateUserDto.ConsultationCost.HasValue)
                //{
                //    user.ConsultationCost = updateUserDto.ConsultationCost.Value;
                //}

                //if (updateUserDto.MeetDateIds.Any())
                //{
                //    user.MeetDates = (await _unitOfWork.Repository<MeetDate>().GetAllAsync(x => updateUserDto.MeetDateIds.Contains(x.Id))).ToList();
                //}

                //if (updateUserDto.ProfessionIds.Any())
                //{
                //    user.Professions = (await _unitOfWork.Repository<Profession>().GetAllAsync(x => updateUserDto.ProfessionIds.Contains(x.Id))).ToList();
                //}

                var result = await _userManager.UpdateAsync(user);
                _unitOfWork.Commit();
                if (result.Succeeded)
                {
                    return new ServiceResult(true);
                }
            }
            return new ServiceResult(false);
        }


        //User


    }
}
