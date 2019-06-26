using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EpicGames.Models;
using EpicGames.App_Start;
using AutoMapper;
using EpicGames.Dtos;
using System.Data.Entity;

namespace EpicGames.Controllers.Api
{
    public class AccountsController : ApiController
    {
        private ApplicationDbContext _context;

        public AccountsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET /api/ accounts
        public IHttpActionResult GetAccounts()
        {
            var accountDtos = _context.Accounts
                .Include(m=>m.ConsoleType)
                .ToList().Select(Mapper.Map<Account, AccountDto>);

            return Ok(accountDtos);
        }

        //GET /api/ accounts/1
        public IHttpActionResult GetAccount(int id)
        {
            var account = _context.Accounts.SingleOrDefault(a => a.AccountID == id);

            if (account == null)
                return NotFound();

            return Ok(Mapper.Map<Account, AccountDto>(account));
        }

        //POST /api/accounts
        [HttpPost]
        public IHttpActionResult CreateAccount(AccountDto accountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var account = Mapper.Map<AccountDto, Account>(accountDto);
            _context.Accounts.Add(account);
            _context.SaveChanges();

            accountDto.AccountID = account.AccountID;

            
            return Created(new Uri(Request.RequestUri + "/" + account.AccountID), accountDto);
        }

        //PUT /api/account/1
        public void UpdateAccount(int id, AccountDto accountDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var accountInDb = _context.Accounts.SingleOrDefault(a => a.AccountID == id);

            if (accountInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(accountDto, accountInDb);


            _context.SaveChanges();
            

        }

        // DELETE /api/account/1
        [HttpDelete]
        public void DeleteAccount(int id)
        {
            var accountinDb = _context.Accounts.SingleOrDefault(a => a.AccountID == id);

            if (accountinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Accounts.Remove(accountinDb);
            _context.SaveChanges();
        }

    }
}
