using System;
using Microsoft.AspNetCore.Mvc;
using MAD.Examen.Models;
using MAD.Examen.WebApi.Authentication;
using MAD.Examen.UnitOfWork;

namespace MAD.Examen.WebApi.Controllers
{


    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : Controller
    {


        private ITokenProvider _tokenProvider;
        private IUnitOfWork _unit;

        public TokenController(ITokenProvider tokenProvider, IUnitOfWork unit)
        {

            _tokenProvider = tokenProvider;
            _unit = unit;

        }



        [HttpPost]
        public JsonWebToken Post([FromBody] User userLogin)
        {

            User user = GetUserByCredentials(userLogin.Email, userLogin.Password);

            if (user == null) throw new UnauthorizedAccessException("No!");

            var lifeInHours = 8;

            var token = new JsonWebToken
            {
                Access_Token = _tokenProvider.CreateToken(user,
                DateTime.UtcNow.AddHours(lifeInHours)),
                Expires_In = lifeInHours * 60

            };

            return token;

        }

        private User GetUserByCredentials(string email, string password)
        {
            return _unit.Users.ValidaterUser(email, password);
        }




    }
}