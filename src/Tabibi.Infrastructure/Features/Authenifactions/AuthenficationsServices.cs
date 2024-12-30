using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Reygency.Infrastructure.UnitOfWorks;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Tabibi.Domain.Shared.Helpers;
using Tabibi.Domain.Shared.Results;
using Tabibi.Domain.Users;
using Tabibi.Infrastructure.Email;

namespace Reygency.Infrastructure.Features.Authenifactions
{
    public sealed class AuthenficationsServices(UserManager<ApplicationUser> userManager,
                                                SignInManager<ApplicationUser> signInManager,
                                                IEmailServices emailServices,
                                                JwtSettings jwtSettings,
                                                IUnitOfWork unitOfWork) : IAuthenficationsServices
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        private readonly IEmailServices _emailServices = emailServices;
        private readonly JwtSettings _jwtSettings = jwtSettings;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<string>> SigninAsync(string userNameOrEmail, string password)
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
                SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
                if (result.Succeeded)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    var role = roles.FirstOrDefault();
                    if (role == "Admin")
                    {
                        (var token, var accessToken) = await GetToken(user, DateTime.Now.AddMonths(5));
                        return Result.Success(accessToken);
                    }
                    else if (role == "Doctor")
                    {
                        var clinic = _unitOfWork.ClinicRepository.GetByUserId(user.Id);
                        (var token, var accessToken) = await GetToken(user, DateTime.Now.AddMonths(5), clinic.Id);
                        return Result.Success(accessToken);
                    }
                    else
                    {
                        (var token, var accessToken) = await GetToken(user, DateTime.Now.AddMonths(5));
                        return Result.Success(accessToken);
                    }
                }
                return Result.Unauthorized<string>("uncorrect password");
            }
            return Result.NotFound($"this user name or email {userNameOrEmail} doesnot exist");
        }

        public async Task<Result<string>> SignupAsync(string userName, string password, string email)
        {
            ApplicationUser user = new()
            {
                UserName = userName,
                Email = email,
                EmailConfirmed = false
            };
            var result = await userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                Random random = new Random();
                user.EmailCode = random.Next(111111, 1000000).ToString();

                await _userManager.UpdateAsync(user);

                var message = $"Confirm email code is: {user.EmailCode}";
                var emailResponse = await _emailServices.SendEmailAsync(user.Email, message, "Confirm Email");
                if (!emailResponse.Succeeded)
                {
                    return emailResponse;
                }
                return Result.Created(user.Id.ToString());
            }
            return Result.BadRequest<string>(result.Errors.FirstOrDefault().Description);
        }

        private async Task<(JwtSecurityToken, string)> GetToken(ApplicationUser applicationUser, DateTime expire, Guid? clinicId = null)
        {
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,applicationUser.Id.ToString()),
                    new Claim(ClaimTypes.Name,applicationUser.UserName),
                    new Claim(ClaimTypes.Email,applicationUser.Email)
                };
            if (clinicId is not null)
            {
                claims.Add(new Claim("ClinicId", clinicId.ToString()));
            }
            var roles = await _userManager.GetRolesAsync(applicationUser);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            var token = new JwtSecurityToken(issuer: _jwtSettings.Issuer,
                                             audience: _jwtSettings.Audience,
                                             claims: claims,
                                             expires: expire,
                                             signingCredentials: new SigningCredentials(new SymmetricSecurityKey(_jwtSettings.GenerateSymmetricKey())
                                                                                        , SecurityAlgorithms.HmacSha256Signature));

            string accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return (token, accessToken);
        }


        private bool isEmail(string email)
        {
            var strings = email.Split("@");
            return strings.Length == 2;
        }
    }
}
