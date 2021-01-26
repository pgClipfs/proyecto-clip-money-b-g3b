using ClipMoney.Application.BusinessLogics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClipMoney.API.Controllers
{
    [Route("api/openturn")]
    [ApiController]
    public class OpenTurnController : Controller
    {

        private readonly OpenTurnBussinesLogic _openTurnBussinesLogic;
        public OpenTurnController(OpenTurnBussinesLogic openTurnBussinesLogic)
        {
            _openTurnBussinesLogic = openTurnBussinesLogic;
        }

        [HttpGet("user/{idUser}")]
        public async Task<IActionResult> GetByIdUser(int idUser)
        {
            var trans = await _openTurnBussinesLogic.GetByUserId(idUser);
            return Ok(trans);
        }

    }
}
