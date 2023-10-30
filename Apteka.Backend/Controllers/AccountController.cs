using Apteka.Backend.DataLayer;
using Apteka.Backend.Model;
using Apteka.Backend.Repository.Account;
using LinqToDB;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Apteka.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]

    public class AccountControllers : ControllerBase
    {
        private readonly IAdminAccountService _account;

        public AccountControllers(IAdminAccountService account)
        {
            _account = account;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllAdminData()
        {
            var get = await _account.GetAllDataAsync();
            if (get.Code == 200 && get.Data is not null)
            {
                return Ok(get);

            }
            if (get.Code == 500 && get.Data is not null)
            {
                return BadRequest(get);

            }
            return NotFound(get);

        }
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var get = await _account.GetByIdAsync(id);
            if (get.Code == 200 && get.Data is not null)
            {
                return Ok(get);
            }
            if (get.Code == 500 && get.Data is not null)
            {
                return BadRequest(get);

            }
            return NotFound(get);
        }
        [HttpDelete]
        public async Task<IActionResult> DelateAsync(string login, string password)
        {
            var del = await _account.DelateAsync(login, password);
            {
                if (del.Code == 200 && del.Data is true)
                {
                    return Ok(del);
                }
                if (del.Code == 500 && del.Data is false)
                {
                    return Ok(del);
                }
                return NotFound(del);
            }

        }
        [HttpPost]
        public async Task<IActionResult> SignUpAdminAsync([FromForm] Admin entity)
        {
            var del = await _account.SignUpAsync(entity);
            {
                if (del.Code == 200 && del.Data is not null)
                {
                    return Ok(del);
                }
                if (del.Code == 500 && del.Data is not null)
                {
                    return Ok(del);
                }
                return NotFound(del);
            }

        }
        [HttpGet]
        public async Task<IActionResult> LigInAdminAsync(string login, string password)
        {
            var del = await _account.LogInAsync(login, password);
            {
                if (del.Code == 200 && del.Data is not null)
                {
                    return Ok(del);
                }
                if (del.Code == 500 && del.Data is not null)
                {
                    return Ok(del);
                }
                return NotFound(del);
            }

        }



    }



}
    
