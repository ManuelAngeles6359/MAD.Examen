using MAD.Examen.Models;
using Microsoft.IdentityModel.Tokens;
using System;

namespace MAD.Examen.WebApi.Authentication
{
    public interface ITokenProvider
    {

        string CreateToken(User user, DateTime expiry);

        TokenValidationParameters GetValidationParameters();

    }
}
