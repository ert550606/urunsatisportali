using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Viewmodel
{
    public class KategoriModel
    {
        public string kategoriId { get; set; }
        public string kategoriAd { get; set; }
        public string urunKatId { get; set; }
        public string satisKatId { get; set; }

        public virtual SatisModel Satis { get; set; }
        public virtual UrunModel Urun { get; set; }
    }
}