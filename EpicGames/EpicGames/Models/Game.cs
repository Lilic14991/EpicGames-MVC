using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EpicGames.Models
{
    public class Game
    {
        public int GameID { get; set; }
        [Display(Name ="Game name")]
        public string GName { get; set; }
        [Display(Name = "Game year")]
        public int GYear { get; set; }
        [Display(Name ="Console type")]
        public string GFor { get; set; }
        public Category Category { get; set; }
        public int CategoryID { get; set; }
        [Display(Name ="Game price")]
        public int PGame { get; set; }
        
    }
}