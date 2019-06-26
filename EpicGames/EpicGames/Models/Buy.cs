using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EpicGames.Models
{
    public class Buy
    {
        public int BuyID { get; set; }

        [Required]
        public int AccountID { get; set; }
        public Account Account { get; set; }

        [Required]
        public int GameID { get; set; }
        public Game Game { get; set; }

        public DateTime BuyDate { get; set; }
    }
}