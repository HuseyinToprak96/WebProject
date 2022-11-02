using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection;

namespace Shared.Layer
{
    public class Security
    {
        private readonly IDataProtector _dataProtector;
        public Security(IDataProtectionProvider dataProtectionProvider, string code)
        {
            _dataProtector = dataProtectionProvider.CreateProtector(code);
        }
        public string Encrypt(int Decrypt)
        {
            var timeLimitedDataProtector = _dataProtector.ToTimeLimitedDataProtector();
            return timeLimitedDataProtector.Protect(Decrypt.ToString());
        }
        public int Decrypt(string Encrypt)
        {
            var timeLimitedDataProtector = _dataProtector.ToTimeLimitedDataProtector();
            return int.Parse(timeLimitedDataProtector.Unprotect(Encrypt));
        }
    }
}
