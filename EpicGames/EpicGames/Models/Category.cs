using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EpicGames.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Display(Name = "Category name")]
        public string CName { get; set; }
        
    }
}