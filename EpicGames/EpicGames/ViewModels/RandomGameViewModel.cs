using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpicGames.Models;

namespace EpicGames.ViewModels
{
    public class RandomGameViewModel
    {
        public Game Game { get; set; }
        public List<Account> Accounts { get; set; }
    }
}