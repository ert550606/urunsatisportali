using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Models.Viewmodel;

namespace WebApplication1.Controllers
{
    public class ServisController : ApiController
    {

         DB03Entities3 db = new DB03Entities3();
        Sonuc1Model sonuc = new Sonuc1Model();
        private object urunId;
        private object uyeId;

        #region Urun

        [HttpGet]
        [Route("api/urunliste")]
            public List<UrunModel> UrunListe()
        {
            List<UrunModel> liste = db.Urun.Select(x => new UrunModel()
            {
                urunId = x.urunId,
                urunAd = x.urunAd,
                urunStok = x.urunStok,
                urunFiyat = x.urunFiyat,
                urunKat = x.urunKat
            }).ToList();

            return liste;
        }

        [HttpGet]
        [Route("api/urunbyid/{urunId}")]
        public UrunModel UyeById(int UrunId)
        { UrunModel kayit = db.Urun.Where(s => s.UrunId == urunId).Select(x => new UrunModel()
        {
            urunId = x.urunId,
            urunAd = x.urunAd,
            urunStok = x.urunStok,
            urunFiyat = x.urunFiyat,
            urunKat = x.urunKat
        }).SingleOrDefault();

            return kayit;
        }
        [HttpPost]
        [Route("api/urunekle")]
        public SonucModel UyeEkle(UrunModel model)
        {
            if (db.Urun.Count(s => s.urunAd == model.urunAd || s.Email == model.Email) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen Kullanıcı Adı veya E-Posta Adresi Kayıtlıdır!";
                return sonuc;
            }
            Urun yeni = new Urun();
            yeni.urunId = model.urunId;
            yeni.urunAd = model.urunAd;
            yeni.urunStok = model.urunStok;
            yeni.urunFiyat = model.urunFiyat;
            yeni.urunKat = model.urunKat;

            db.Urun.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Ürün Eklendi";
            return sonuc;
        }
        [HttpPut]
        [Route("api/urunduzenle")]
        public SonucModel UyeDuzenle(UrunModel model)
        {
            Urun kayit = db.Urun.Where(s => s.UyeId == model.UyeId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı";
                return sonuc;
            }
            
            kayit.urunId = model.urunId;
            kayit.urunAd = model.urunAd;
            kayit.urunStok = model.urunStok;
            kayit.urunFiyat = model.urunFiyat;
            kayit.urunKat = model.urunKat;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Ürün Düzenlendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/urunsil/{urunId}")]
        public SonucModel urunsil(int urunId)
        {
            Urun kayit = db.Urun.Where(s => s.UyeId == uyeId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Ürün Bulunamadı";
                return sonuc;
            }
            if (db.Makale.Count(s => s.urunId == urunId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üzerinde Makale Kaydı Olan Üye Silinemez!";
                return sonuc;
            }
            if (db.Yorum.Count(s => s.urunId == urunId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üzerinde Yorum Kaydı Olan Üye Silinemez!";
                return sonuc;
            }
            db.Urun.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Ürün Silindi";
            return sonuc;
        }



        #endregion

        #region Satis

        [HttpGet]
        [Route("api/satisliste")]
        public List<SatisModel> SatisListe()
        {
            List<SatisModel> liste = db.Satis.Select(x => new SatisModel()
            {
                satisId = x.satisId,
                satisUrunad = x.satisUrunad,
                satisMiktar = x.satisMiktar,
                satisFiyat = x.satisFiyat,
                satisYüzde = x.satisYüzde,
                satisKat = x.satisKat,
                satisTarih = x.satisTarih,
                
            }).ToList();
            return liste;
        }



        [HttpGet]
             [Route("api/satisurunadsoneklenenler/{s}")]
             public List<SatisModel> satisurunadsoneklenenler(int s)
             {
             List<SatisModel> liste = db.Satis.OrderByDescending(o => o.satisId).Take(
           s).Select(x => new SatisModel()
           {
               satisId = x.satisId,
               satisUrunad = x.satisUrunad,
               satisMiktar = x.satisMiktar,
               satisFiyat = x.satisFiyat,
               satisYüzde = x.satisYüzde,
               satisKat = x.satisKat,
               satisTarih = x.satisTarih,
           }).ToList();
            return liste;
        }


        [HttpGet]
        [Route("api/satisId/{Id}")]
        public List<SatisModel> SatisId(int SatisId)
        {
            List<SatisModel> liste = db.Satis.Where(s => s.KategoriId == satisId).Select
           (x => new SatisModel()
           {
               satisId = x.satisId,
               satisUrunad = x.satisUrunad,
               satisMiktar = x.satisMiktar,
               satisFiyat = x.satisFiyat,
               satisYüzde = x.satisYüzde,
               satisKat = x.satisKat,
               satisTarih = x.satisTarih,


               #endregion
           }
    
