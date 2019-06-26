using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EpicGames.Models;

namespace EpicGames.ViewModels
{
    public class BuyFormViewModel
    {
        public IEnumerable<Account> Accounts { get; set; }
        public IEnumerable<Game> Games { get; set; }

        public int BuyID { get; set; }

        public int AccountID { get; set; }
        public int GameID { get; set; }
        public DateTime BuyDate { get; set; }

        public BuyFormViewModel()
        {
            BuyID = 0;
            BuyDate = DateTime.Now;
        }

        public BuyFormViewModel(Buy buy)
        {
            BuyID = buy.BuyID;
            AccountID = buy.AccountID;
            GameID = buy.GameID;
            BuyDate = buy.BuyDate;
        }
    }
}