using Microsoft.AspNetCore.Identity;
using Reygency.Infrastructure.UnitOfWorks;
using Tabibi.Domain.Shared.Results;
using Tabibi.Domain.Users;
using Tabibi.Infrastructure.Email;

namespace Tabibi.Infrastructure.Features.Users
{
    public sealed class UserServices(UserManager<ApplicationUser> userManager,
        IEmailServices emailServices,
        IUnitOfWork unitOfWork) : IUserServices
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IEmailServices _emailServices = emailServices;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<string>> AddAdminAsync(string userName, string password, string email)
        {
            ApplicationUser user = new()
            {
                UserName = userName,
                Email = email,
                EmailConfirmed = true
            };
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
                return Result.Created(user.Id.ToString());
            }
            return Result.BadRequest<string>(result.Errors.FirstOrDefault().Description);
        }

        public async Task<Result<string>> ConfirmEmailAsync(string emailOrUserName, string code)
        {
            ApplicationUser user;
            if (isEmail(emailOrUserName))
            {
                user = await _userManager.FindByEmailAsync(emailOrUserName);
            }
            else
            {
                user = await _userManager.FindByNameAsync(emailOrUserName);
            }

            if (user is not null)
            {
                if (user.EmailCode == code)
                {
                    user.EmailConfirmed = true;
                    user.EmailCode = null;
                    await _userManager.UpdateAsync(user);
                    return Result.Success(user.Id.ToString());
                }
                return Result.BadRequest<string>("code is encorrect");
            }

            return Result.NotFound($"this user name or email {emailOrUserName} doesnot exist");

        }

        public async Task<Result<string>> DeleteAsync(Guid Id)
        {
            var user = GetById(Id);
            if (user is null)
            {
                return Result.NotFound("Id does not exist");
            }
            await _unitOfWork.SaveChangesAsync();
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Result.Deleted<string>();
            }

            return Result.BadRequest<string>(result.Errors.FirstOrDefault().Description);
        }

        public IQueryable<ApplicationUser> GetAll()
        {
            return _userManager.Users;
        }

        public ApplicationUser? GetById(Guid id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public (IQueryable<ApplicationUser>, int) GetByPaginaion(int pageNumber, int pageSize, string? search)
        {
            IQueryable<ApplicationUser> users;
            int count = 0;
            if (search is null)
            {
                users = _userManager.Users;
                _userManager.Users.Count();
            }
            else
            {
                users = _userManager.Users.Where(x => x.UserName.Contains(search) || x.Email.Contains(search));
                count = _userManager.Users.Where(x => x.UserName.Contains(search) || x.Email.Contains(search)).Count();
            }
            return (users.Skip((pageNumber - 1) * pageSize).Take(pageSize), count);
        }

        public bool IsIdExist(Guid Id)
        {
            return _userManager.Users.Any(x => x.Id == Id);
        }

        public bool IsUserNameExist(string userName)
        {
            return _userManager.Users.Any(u => u.UserName == userName);
        }
        public async Task<Result<string>> ResetPasswordAsync(string userNameOrEmail, string code, string newPassword)
        {
            ApplicationUser user;
            if (isEmail(userNameOrEmail))
            {
                user = await _userManager.FindByEmailAsync(userNameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(userNameOrEmail);
            }

            if (user is not null)
            {
                if (user.ForgetPasswordCode == code)
                {
                    await _userManager.RemovePasswordAsync(user);
                    var result = await _userManager.AddPasswordAsync(user, newPassword);
                    if (result.Succeeded)
                    {
                        user.ForgetPasswordCode = null;
                        await _userManager.UpdateAsync(user);
                        return Result.Success(user.Id.ToString());
                    }
                    return Result.BadRequest<string>(result.Errors.First().Description);
                }
                return Result.BadRequest<string>($"code {code} is ancorrect");
            }

            return Result.NotFound($"this user name or email {userNameOrEmail} doesnot exist");
        }
        public async Task<Result<string>> SendForgetPasswordCodeAsync(string userNameOrEmail)
        {
            ApplicationUser user;
            if (isEmail(userNameOrEmail))
            {
                user = await _userManager.FindByEmailAsync(userNameOrEmail);
            }
            else
            {
                user = await _userManager.FindByNameAsync(userNameOrEmail);
            }

            if (user is not null)
            {
                Random random = new Random();
                user.ForgetPasswordCode = random.Next(111111, 1000000).ToString();
                await _userManager.UpdateAsync(user);
                var message = $"Reset passwor code is: {user.ForgetPasswordCode}";
                var emailResponse = await _emailServices.SendEmailAsync(user.Email, message, "reset password");
                if (!emailResponse.Succeeded)
                {
                    return emailResponse;
                }
                return Result.Success(user.Id.ToString());
            }
            return Result.NotFound($"this user name or email {userNameOrEmail} doesnot exist");
        }
        private bool isEmail(string email)
        {
            var strings = email.Split("@");
            return strings.Length == 2;
        }
    }
}
