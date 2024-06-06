using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace RBACSample.Services;

public interface IAuthenticationService
{
    Task<bool> VerifyUser(string username, SecureString password);
}