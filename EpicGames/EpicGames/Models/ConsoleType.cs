using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EpicGames.Models
{
    public class ConsoleType
    {
        public byte ConsoleTypeID { get; set; }
        public string CName { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
    }
}