using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EpicGames.Models;
using EpicGames.ViewModels;
using System.Data.Entity;

namespace EpicGames.Controllers
{
    
    public class GamesController : Controller
    {
        
        public ActionResult New()
        {
            var Categories = _context.Categories.ToList();
            var ViewModel = new GameFormViewModel
            {
                Game = new Game(),
                Categories = Categories
            };

            return View("GameForm", ViewModel);
        }



        ApplicationDbContext _context;

        public GamesController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Game game)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new GameFormViewModel
                {
                    Game = game,
                    Categories = _context.Categories.ToList()
                };

                return View("GameForm", viewModel);
            }

            if(game.GameID == 0)
            {
                _context.Games.Add(game);
            }
            else
            {
                var gameInDb = _context.Games.Single(g => g.GameID == game.GameID);

                gameInDb.GName = game.GName;
                gameInDb.GYear = game.GYear;
                gameInDb.GFor = game.GFor;
                gameInDb.PGame = game.PGame;
                gameInDb.CategoryID = game.CategoryID;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Games"); 
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult Details(int id)
        {
            var game = _context.Games.SingleOrDefault(g => g.GameID == id);

            if (game == null)
            {
                return HttpNotFound();
            }

            return View(game);
        }

        // GET: Games
        [AllowAnonymous]
        public ViewResult Index()
        {
            var games = _context.Games.Include(b => b.Category).ToList();

            return View(games);
        }


        public ActionResult Edit(int id)
        {
            var game = _context.Games.SingleOrDefault(g => g.GameID == id);
            if (game == null)
            {
                return HttpNotFound();
            }

            var viewModel = new GameFormViewModel
            {
                Game = game,
                Categories = _context.Categories.ToList()
            };

            return View("GameForm", viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Game game = _context.Games.Find(id);

            return View(game);

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                Game game = _context.Games.Find(id);
                _context.Games.Remove(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index");
        }

        /*
        private IEnumerable<Game> GetGames()
        {
            return new List<Game>
            {
                new Game {GameID = 1, GName = "Doutless"},
                new Game {GameID = 2, GName = "Watch Dogs"},
            };
        }

        public ActionResult Random()
        {
            var game = new Game() { GName = "Doutless" };
            var accounts = new List<Account>
            {
                new Account {AName = "Account 1"},
                new Account {AName = "Account 2"}
            };

            var viewModel = new RandomGameViewModel
            {
                Game = game,
                Accounts = accounts
            };

            return View(viewModel);
        }
        */
    }
    
}