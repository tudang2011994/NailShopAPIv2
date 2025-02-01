public interface IOTPService
{
    string GenerateOTP();
    Task SendOTPAsync(string phoneNumber, string otp);
    Task<bool> VerifyOTPAsync(string phoneNumber, string otp);
}
