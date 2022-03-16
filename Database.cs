using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Console_Telefon_Rehberi_Uygulaması
{
    public class Database
    {
        private static List<Rehber> rehber = new();

        static Database()
        {
            Baslangic();
        }

        public static void Baslangic()
        {
            KayitEkle(new Rehber()
            {
                Isim = "Ahmet",
                Soyisim = "Yılmaz",
                Numara = "0555555555",
            });
            KayitEkle(new Rehber()
            {
                Isim = "Mehmet",
                Soyisim = "Yılmaz",
                Numara = "0555555555",
            });
            KayitEkle(new Rehber()
            {
                Isim = "Ali",
                Soyisim = "Yılmaz",
                Numara = "0555555555",
            });
            KayitEkle(new Rehber()
            {
                Isim = "Veli",
                Soyisim = "Yılmaz",
                Numara = "0555555555",
            });
            KayitEkle(new Rehber()
            {
                Isim = "Ayşe",
                Soyisim = "Yılmaz",
                Numara = "0555555555",
            });
        }

        public static void KayitEkle(Rehber rehber)
        {
            Database.rehber.Add(rehber);
        }

        public static void Sil(Rehber rehber)
        {
            Database.rehber.Remove(rehber);
        }

        public static List<Rehber> GetAll()
        {
            return rehber;
        }

        public static Rehber GetByName(String isim)
        {
            Rehber dbRehber = rehber.FirstOrDefault(x => x.Isim.ToLower() == isim.ToLower() || x.Soyisim.ToLower() == isim.ToLower());

            return dbRehber;
        }
        

    }
}