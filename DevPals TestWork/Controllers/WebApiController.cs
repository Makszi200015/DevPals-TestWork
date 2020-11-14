using DevPals_TestWork.Models;
using DevPals_TestWork.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevPals_TestWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiController : ControllerBase
    {
        private CustomerService CustomerService;
        private HistoryService HistoryService;

        public WebApiController(CustomerService customerService, HistoryService historyService)
        {
            CustomerService = customerService;
            HistoryService = historyService;
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string UserName, string Pin)
        {
            if (UserName != null && Pin != null)
            {
                if (CustomerService.Login(UserName, Pin))
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
        [HttpGet]
        [Route("GetBalance")]
        public IActionResult GetBalance(string UserName)
        {
            if (UserName != null)
            {
                return Ok(CustomerService.GetBalance(UserName));
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("CashedOut")]
        public IActionResult CashedOut(int? WithdrawnCash, string UserName)
        {
            if (UserName != null && WithdrawnCash != null)
            {
                string resultMessage = "Insufficient funds on the card";
                HistoryModel history = new HistoryModel { UsedUserName = UserName, WithdrawnCash = WithdrawnCash.Value };
                if (WithdrawnCash <= CustomerService.GetBalance(UserName))
                {
                    resultMessage = "Please take your money";
                    history.OperationState = true;
                    CustomerService.BalanceUpdate(WithdrawnCash.Value, UserName);
                }
                HistoryService.Add(history);
                return Ok(new { history=HistoryService.GetHistory(UserName), resultMessage });
            }
            return BadRequest();
        }
    }
}
