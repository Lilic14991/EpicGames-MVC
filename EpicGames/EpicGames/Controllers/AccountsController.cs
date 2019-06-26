using EpicGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpicGames.ViewModels;
using System.Data.Entity;


namespace EpicGames.Controllers
{
    public class AccountsController : Controller
    {

        [HttpPost]
        public ActionResult Save(Account account)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new AccountFormViewModel
                {
                    Account = account,
                    ConsoleTypes = _context.ConsoleTypes.ToList()
                };

                return View("AccountForm",viewModel);
            }

            if (account.AccountID == 0)
            {
                _context.Accounts.Add(account);
            }
            else
            {
                var accountInDb = _context.Accounts.Single(a => a.AccountID == account.AccountID);

                accountInDb.AName = account.AName;
                accountInDb.IsSubcribedOnEpicGames = account.IsSubcribedOnEpicGames;
                accountInDb.ConsoleTypeID = account.ConsoleTypeID;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Accounts");
        }

        private ApplicationDbContext _context;

        public AccountsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        
        public ViewResult Index()
        {
            if(User.IsInRole(RoleName.CanManageAccounts))
                return View("List");

            return View("ReadOnlyList");
            

        }
        



        // GET: Accounts
        
        public ActionResult Details(int id)
        {
            var account = _context.Accounts.SingleOrDefault(a => a.AccountID == id);

            if(account == null)
            {
                return HttpNotFound();
            }

            return View(account);
        }
        [Authorize(Roles = RoleName.CanManageAccounts)]
        public ActionResult New()
        {
            var ConsoleType = _context.ConsoleTypes.ToList();
            var ViewModel = new AccountFormViewModel
            {
                Account = new Account(),
                ConsoleTypes = ConsoleType
            };
            return View("AccountForm",ViewModel);
        }

        public ActionResult Edit(int id)
        {
            var account = _context.Accounts.SingleOrDefault(a => a.AccountID == id);
                if(account == null)
                {
                    return HttpNotFound();
                }

            var viewModel = new AccountFormViewModel
            {
                Account = account,
                ConsoleTypes = _context.ConsoleTypes.ToList()
            };

            return View("AccountForm", viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Account account = _context.Accounts.Find(id);

            return View(account);
           
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                Account account = _context.Accounts.Find(id);
                _context.Accounts.Remove(account);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index");
        }


    }
}