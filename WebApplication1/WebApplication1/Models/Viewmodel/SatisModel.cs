using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Viewmodel
{
    public class SatisModel
    {
        public string satisId { get; set; }
        public string satisUrunad { get; set; }
        public int satisMiktar { get; set; }
        public double satisFiyat { get; set; }
        public double satisYüzde { get; set; }
        public string satisKat { get; set; }
        public int satisTarih { get; set; }
    }
}