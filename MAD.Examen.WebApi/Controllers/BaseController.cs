﻿using MAD.Examen.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MAD.Examen.WebApi.Controllers
{

    [Produces("application/json")]
    [Authorize]
    public class BaseController : Controller
    {

        protected IUnitOfWork _unit;

        public BaseController(IUnitOfWork unit)
        {
            _unit = unit;
        }


    }
}
