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
    [Route("api/wallet")]
    [ApiController]
    [AllowAnonymous]
    public class WalletController : ControllerBase
    {
        private readonly WalletBussinesLogic _walletBussinesLogic;
        public WalletController(WalletBussinesLogic walletBussinesLogic)
        {
            _walletBussinesLogic = walletBussinesLogic;
        }
        [HttpPost("insert/user")]
        public async Task<IActionResult> Post(TransferModel transaction)
        {
            var trc = await _walletBussinesLogic.Post(transaction);
            return Ok(trc);
        }

        [HttpGet("funds/{userId}")]
        public async Task<IActionResult>GetFundsByUserId(int userId)
        {
            var funds = await _walletBussinesLogic.GetFundsByUserId(userId);
            return Ok(funds);
        }
    }
}
