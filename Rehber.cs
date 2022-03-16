using System;


namespace Console_Telefon_Rehberi_Uygulaması
{
    public class Rehber
    {
        public String Isim { get; set; }
        public String Soyisim { get; set; }
        public String Numara { get; set; }

        public override string ToString()
        {
            return " İsim: " + Isim + "\n"
                   + " Soyisim: " + Soyisim + "\n"
                   + " Telefon Numarası: " + Numara + "\n"
                   + " -";
        }
    }

}