using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Viewmodel
{
    public class SonucModel
    {
        public string SonucId { get; set; }
        public int karMiktar { get; set; }
        public double karYüzde { get; set; }
        public double hedefYüzde { get; set; }
        public string sonucsatisId { get; set; }

        public virtual SatisModel Satis { get; set; }
    }
}