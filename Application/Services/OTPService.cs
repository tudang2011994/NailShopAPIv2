using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

public class OTPService : IOTPService
{
    private readonly Dictionary<string, string> _otpStore = new Dictionary<string, string>();
    private readonly string _twilioAccountSid;
    private readonly string _twilioAuthToken;
    private readonly string _twilioPhoneNumber;

    public OTPService(string twilioAccountSid, string twilioAuthToken, string twilioPhoneNumber)
    {
        _twilioAccountSid = twilioAccountSid;
        _twilioAuthToken = twilioAuthToken;
        _twilioPhoneNumber = twilioPhoneNumber;
    }

    public string GenerateOTP()
    {
        var random = new Random();
        return random.Next(100000, 999999).ToString();
    }

    public async Task SendOTPAsync(string phoneNumber, string otp)
    {
        TwilioClient.Init(_twilioAccountSid, _twilioAuthToken);

        var message = await MessageResource.CreateAsync(
            body: $"Your OTP code is {otp}",
            from: new Twilio.Types.PhoneNumber(_twilioPhoneNumber),
            to: new Twilio.Types.PhoneNumber(phoneNumber)
        );

        _otpStore[phoneNumber] = otp;
    }

    public async Task<bool> VerifyOTPAsync(string phoneNumber, string otp)
    {
        return _otpStore.ContainsKey(phoneNumber) && _otpStore[phoneNumber] == otp;
    }
}
