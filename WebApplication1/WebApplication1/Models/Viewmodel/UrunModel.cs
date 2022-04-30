using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Viewmodel
{
    public class UrunModel
    {
        internal object Email;
        internal object UyeId;

        public string urunId { get; set; }
        public string urunAd { get; set; }
        public int urunStok { get; set; }
        public double urunFiyat { get; set; }
        public string urunKat { get; set; }
    }
}