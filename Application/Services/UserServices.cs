using System;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Application.Interfaces.Services;
using Google.Apis.Auth;

public class UserServices : IUserServices
{
    private readonly IUserRepository _userRepository;
    private readonly IOTPService _otpService;

    public UserServices(IUserRepository userRepository, IOTPService otpService)
    {
        _userRepository = userRepository;
        _otpService = otpService;
    }

    public async Task<User> getUserByPhoneNumberAsync(string phoneNumber)
    {
        return await _userRepository.getUserByPhoneNumberAsync(phoneNumber);
    }

    public async Task<User> RegisterUserAsync(string phoneNumber, string email, string password)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            PhoneNumber = phoneNumber,
            Email = email,
            Password = password,
            isRegisterUser = true
        };
        await _userRepository.addUserAsync(user);
        await _userRepository.saveChangesAsync();
        return user;
    }

    public async Task<User> AuthenticateUserAsync(string phoneNumber, string password)
    {
        var user = await _userRepository.getUserByPhoneNumberAsync(phoneNumber);
        if (user == null || user.Password != password)
        {
            throw new UnauthorizedAccessException();
        }
        return user;
    }

    public async Task<User> AuthenticateWithGoogleAsync(string idToken)
    {
        var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
        var user = await _userRepository.getUserByEmailAsync(payload.Email);
        if (user == null)
        {
            user = new User
            {
                Id = Guid.NewGuid(),
                Email = payload.Email,
                Name = payload.Name,
                GoogleId = payload.Subject,
                isRegisterUser = true
            };
            await _userRepository.addUserAsync(user);
            await _userRepository.saveChangesAsync();
        }
        return user;
    }

    public async Task<User> AuthenticateWithOTPAsync(string phoneNumber, string otp)
    {
        var isValidOTP = await _otpService.VerifyOTPAsync(phoneNumber, otp);
        if (!isValidOTP)
        {
            throw new UnauthorizedAccessException();
        }
        var user = await _userRepository.getUserByPhoneNumberAsync(phoneNumber);
        if (user == null)
        {
            throw new UnauthorizedAccessException();
        }
        return user;
    }

    public async Task SendOTPAsync(string phoneNumber)
    {
        var otp = _otpService.GenerateOTP();
        await _otpService.SendOTPAsync(phoneNumber, otp);
    }
}