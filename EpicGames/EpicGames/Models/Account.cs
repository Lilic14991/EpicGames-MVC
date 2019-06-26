using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EpicGames.Models
{
    public class Account
    {
        public int AccountID { get; set; }
        [Required]
        [StringLength(255)]
        public string AName { get; set; }
        public bool IsSubcribedOnEpicGames { get; set; }
        public ConsoleType ConsoleType { get; set; }
        public byte ConsoleTypeID { get; set; }
    }
}