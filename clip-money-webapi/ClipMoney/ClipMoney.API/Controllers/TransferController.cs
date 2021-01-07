using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClipMoney.Application.BusinessLogics;
using ClipMoney.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClipMoney.API.Controllers
{
    [Route("api/transfer")]
    [ApiController]
    [AllowAnonymous]
    public class TransferController : ControllerBase
    {
        private readonly TransferBussinesLogic _transferBussinesLogic;

        public TransferController(TransferBussinesLogic transferBussinesLogic)
        {
            _transferBussinesLogic = transferBussinesLogic;
        }

        [HttpGet("user/{idUser}")]
        public async Task<IActionResult> GetByIdUser(int idUser)
        {
            var trc = await _transferBussinesLogic.GetByIdUser(idUser);
            return Ok(trc);
        }
    }
}