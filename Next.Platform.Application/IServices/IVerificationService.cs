using System;
using System.Collections.Generic;
using System.Text;

namespace Next.Platform.Application.IServices
{
  public  interface IVerificationService
  {
      string SendVerificationCode(string to);
      string CheckVerificationCode(string to ,string verificationCode);
      string NumberToInternationalFormat(string number);
  }
}
