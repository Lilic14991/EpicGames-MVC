using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpicGames.Models;

namespace EpicGames.ViewModels
{
    public class AccountFormViewModel
    {
        public IEnumerable<ConsoleType> ConsoleTypes { get; set; }
        public Account Account { get; set; }
    }
}