using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpicGames.Models;

namespace EpicGames.ViewModels
{
    public class CategoryFormViewModel
    {
        public Category Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}