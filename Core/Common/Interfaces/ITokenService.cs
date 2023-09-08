using System;
using Core.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Core.Common.Interfaces
{
	public interface ITokenService
	{
        string CreateToken(IdentityUser user);
    }
}

