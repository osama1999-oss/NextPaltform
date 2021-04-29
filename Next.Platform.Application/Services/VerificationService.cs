using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Next.Platform.Application.IServices;
using Twilio.Rest.Verify.V2.Service;

namespace Next.Platform.Application.Services
{
  public  class VerificationService: IVerificationService
    {
        public VerificationService()
        {
            
        }
        public string SendVerificationCode(string to)
        {
            string  pathServiceSid = "VA888a34af78a72a9324e1459fd9f5bfd4";
            string  channel = "sms";

            var verification = VerificationResource.Create(pathServiceSid , to ,channel);
            return verification.Status;
        }

        public string CheckVerificationCode(string to, string verificationCode)
        {
            string pathServiceSid = "VA888a34af78a72a9324e1459fd9f5bfd4";

            var verification = VerificationCheckResource.CreateAsync(
                to:to,
                code: verificationCode,
                pathServiceSid: pathServiceSid
            );

            return verification.Result.Status;
        }
        //01234567891011
        //01100384373
        //to: "+20-11-0038-4373",
        public string NumberToInternationalFormat(string number)
        { 
            char[] digits = number.ToCharArray();
            string  internationalNumberFormat = "+20-" + digits[1]+digits[2] + "-" +digits[3] + digits[4] + digits[5]
                                         + digits[6]+ "-"+digits[7] + digits[8] + digits[9] + digits[10];

            return internationalNumberFormat;

        }
    }
}
