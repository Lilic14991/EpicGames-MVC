using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpicGames.Models;

namespace EpicGames.ViewModels
{
    public class GameFormViewModel
    {
        public Game Game { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}