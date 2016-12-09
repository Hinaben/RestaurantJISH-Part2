using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantJISH_Part2.Models
{
    //join 2 table for category and menu
    public class joinModel

    {
        public Categories foodCategory { get; set; }
        public menus foodItem { get; set; }
    }
}