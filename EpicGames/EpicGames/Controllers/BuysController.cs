using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpicGames.Models;
using EpicGames.ViewModels;

namespace EpicGames.Controllers
{
    [Authorize(Roles = RoleName.CanManageAccounts)]
    public class BuysController : Controller
    {
        // GET: Buys
        public ActionResult Index()
        {
            var buy = _context.Buys.ToList();

            return View(buy);
        }

        ApplicationDbContext _context;

         public BuysController()
        {
            _context = new ApplicationDbContext();
        }

        public ViewResult New()
        {
            var accounts = _context.Accounts.ToList();

            var games = _context.Games.ToList();

            var viewModel = new BuyFormViewModel
            {
                Accounts = accounts,
                Games = games

            };

            return View("BuyForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Buy buy)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new BuyFormViewModel
                {
                    Accounts = _context.Accounts.ToList(),
                    Games = _context.Games.ToList()
                };

                return View("BuyForm", viewModel);
            }

            if(buy.BuyID == 0)
            {
                buy.BuyDate = DateTime.Now;
                _context.Buys.Add(buy);
            }

            else
            {
                var buyInDb = _context.Buys.Single(b => b.BuyID == buy.BuyID);

                buyInDb.AccountID = buy.AccountID;
                buyInDb.GameID = buy.GameID;
            }
           _context.SaveChanges();
            return RedirectToAction("Index", "Buys");
        }

        public ActionResult Edit(int id)
        {
            var buy = _context.Buys.SingleOrDefault(b => b.BuyID == id);
            if(buy == null)
            {
                return HttpNotFound();
            }

            var viewModel = new BuyFormViewModel(buy)
            {
                Accounts = _context.Accounts.ToList(),
                Games = _context.Games.ToList()
            };

            return View("BuyForm", viewModel);
        }



        public ActionResult Details(int id)
        {
            var buy = _context.Buys.SingleOrDefault(b => b.BuyID == id);
            

            if(buy == null)
            {
                return HttpNotFound();
            }
            return View(buy);
        }
        

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Buy buy = _context.Buys.Find(id);
            return View(buy);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm (int id)
        {
            if(ModelState.IsValid)
            {
                Buy buy = _context.Buys.Find(id);
                _context.Buys.Remove(buy);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

    }
}