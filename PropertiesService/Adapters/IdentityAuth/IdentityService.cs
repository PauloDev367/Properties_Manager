using Application;
using Application.DTO.Request.Auth;
using Application.DTO.Response.Auth;
using Application.User.Ports;
using Domain.Ports;
using IdentityAuth.Jwt;
using Microsoft.AspNetCore.Identity;
namespace IdentityAuth;

public class IdentityService : IAuthenticationService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtGenerator _jwtGenerator;
    private readonly IUserService _userService;

    public IdentityService(
        SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        JwtGenerator jwtGenerator,
        IUserService userService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtGenerator = jwtGenerator;
        _userService = userService;
    }

    public async Task<UserLoginResponseDto> AuthenticateAsync(UserLoginRequestDto request)
    {
        var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, true);
        if (result.Succeeded)
            return await _jwtGenerator.GerarToken(request.Email);

        var userAuth = new UserLoginResponseDto();
        if (!result.Succeeded)
        {
            if (result.IsLockedOut)
                userAuth.AddError("Conta bloqueada");
            else if (result.IsNotAllowed)
                userAuth.AddError("Essa conta não tem permissão para essa ação");
            else if (result.RequiresTwoFactor)
                userAuth.AddError("É necessário confirmar o login com o código de 2 fatores");
            else
                userAuth.AddError("Usuário ou senha inválidos");
        }

        return userAuth;
    }

    public async Task<CreatedUserDto> RegisterAsync(CreateUserDto register)
    {
        var identityUser = new IdentityUser
        {
            UserName = register.Email,
            Email = register.Email,
            EmailConfirmed = true
        };
        var result = await _userManager.CreateAsync(identityUser, register.Password);
        var response = new CreatedUserDto();
        if (result.Succeeded)
        {
            await _userManager.SetLockoutEnabledAsync(identityUser, false);
            response = await _userService.CreateAsync(register, identityUser.PasswordHash);
        }
        else
        {
            response.SetError(result.Errors.ToList().Select(r => r.Description).ToList());
        }
        return response;
    }
}
