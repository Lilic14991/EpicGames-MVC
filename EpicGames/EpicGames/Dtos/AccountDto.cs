using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EpicGames.Models;

namespace EpicGames.Dtos
{
    public class AccountDto
    {
        public int AccountID { get; set; }
        [Required]
        [StringLength(255)]
        public string AName { get; set; }
        public bool IsSubcribedOnEpicGames { get; set; }
        public ConsoleTypeDto ConsoleType { get; set; }
        public byte ConsoleTypeID { get; set; }


    }
}