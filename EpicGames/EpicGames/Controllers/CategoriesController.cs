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
    public class CategoriesController : Controller
    {
        // GET: Categories
        

        private ApplicationDbContext _context;

        public CategoriesController ()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public ActionResult Save(Category category)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CategoryFormViewModel
                {
                    Category = category,
                    Categories = _context.Categories.ToList()
                };

                return View("CategoryForm", viewModel);
            }

            if (category.CategoryID == 0)
            {
                _context.Categories.Add(category);
            }
            else
            {
                var categoryInDb = _context.Categories.Single(c => c.CategoryID == category.CategoryID);

                categoryInDb.CName = category.CName;
               }

            _context.SaveChanges();
            return RedirectToAction("Index", "Categories");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var categories = _context.Categories.ToList();

            return View(categories);
        }

        public ActionResult New()
        {
            var Category = _context.Categories.ToList();
            var ViewModel = new CategoryFormViewModel
            {
                Category = new Category(),
                
            };
            return View("CategoryForm", ViewModel);
        }

        public ActionResult Edit(int id)
        {
            var category = _context.Categories.SingleOrDefault(g => g.CategoryID == id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CategoryFormViewModel
            {
                Category = category,
            };
                

            return View("CategoryForm", viewModel);
        }

        public ActionResult Delete (int id)
        {
            Category category = _context.Categories.Find(id);

            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                Category category = _context.Categories.Find(id);
                _context.Categories.Remove(category);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.CategoryID == id);

            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }
    }
}