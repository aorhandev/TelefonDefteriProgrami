using System;
using System.Linq;


namespace Console_Telefon_Rehberi_Uygulaması
{
    public class Islemler
    {

        public static void SecimAraci()
        {
            while (true)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Yeni Numara Kaydetmek");
                Console.WriteLine("(2) Varolan Numarayı Silmek");
                Console.WriteLine("(3) Varolan Numarayı Güncelleme");
                Console.WriteLine("(4) Rehberi Listelemek");
                Console.WriteLine("(5) Rehberde Arama Yapmak");
                Console.WriteLine("*******************************************");
                Console.WriteLine("Çıkmak İçin (E) Tuşuna Basınız");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Islemler.Kaydetme();
                        break;
                    case "2":
                        Islemler.Silme();
                        break;
                    case "3":
                        Islemler.Guncelleme();
                        break;
                    case "4":
                        Islemler.Listeleme();
                        break;
                    case "5":
                        Islemler.Arama();
                        break;
                    case "E":
                        Environment.Exit(0);
                        break;
                    case "e":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Lütfen geçerli bir işlem seçiniz.");
                        break;
                }
            }
        }

        public static void Kaydetme()
        {
            Console.WriteLine(" Lütfen isim giriniz.");

            string isim = Console.ReadLine();

            isim = isim[0].ToString().ToUpper() + isim.Substring(1).ToLower();

            if (string.IsNullOrEmpty(isim))
            {
                Console.WriteLine(" Lütfen geçerli isim giriniz.");
                Kaydetme();
            }

            Console.WriteLine(" Lütfen soyisim giriniz.");
            string soyisim = Console.ReadLine();

            soyisim = soyisim[0].ToString().ToUpper() + soyisim.Substring(1).ToLower();

            while (string.IsNullOrEmpty(soyisim))
            {
                Console.WriteLine(" Lütfen geçerli soyisim giriniz.");
                soyisim = Console.ReadLine();
            }

            Console.WriteLine(" Lütfen numaranızı giriniz.");
            string numara = Console.ReadLine();

            while (string.IsNullOrEmpty(numara))
            {
                Console.WriteLine(" Lütfen geçerli numara giriniz.");
                numara = Console.ReadLine();
            }

            Database.KayitEkle(new Rehber()
            {
                Isim = isim,
                Soyisim = soyisim,
                Numara = numara,
            });

            Console.WriteLine(" Kayıt başarılı.");
        }

        public static void Silme()
        {
            Console.WriteLine(" Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");

            string isim = Console.ReadLine();

            if (string.IsNullOrEmpty(isim))
            {
                Console.WriteLine(" Lütfen bir isim giriniz.");
                Silme();
            }


            Rehber dbRehber = Database.GetByName(isim);

            if (dbRehber != null)
            {
                Console.WriteLine(" {0} {1} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n)", dbRehber.Isim, dbRehber.Soyisim);
                if (Console.ReadLine() == "y")
                {
                    Database.Sil(dbRehber);
                    Console.WriteLine(" {0} {1} isimli kişi rehberden silindi.", dbRehber.Isim, dbRehber.Soyisim);
                    Console.WriteLine(" Silme işlemi başarılı.");
                }
                else
                {
                    Console.WriteLine(" {0} {1} isimli kişi rehberden silinmedi.", dbRehber.Isim, dbRehber.Soyisim);
                    Silme();
                }
            }
            else
            {
                Console.WriteLine(" Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine(" * Silmeyi sonlandırmak için : (1)");
                Console.WriteLine(" * Yeniden denemek için      : (2)");
                string secim = Console.ReadLine();
                
                switch (secim)
                {
                    case "1":
                        break;
                    case "2":
                        Silme();
                        break;
                    default:
                        Console.WriteLine(" Lütfen geçerli bir işlem seçiniz.");
                        Silme();
                        break;
                }
            }
        }

        public static void Guncelleme()
        {
            Console.WriteLine(" Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
            string isim = Console.ReadLine();
            if (string.IsNullOrEmpty(isim)){
                Console.WriteLine(" Lütfen bir isim giriniz.");
                Guncelleme();
            }
        
            Rehber dbRehber = Database.GetByName(isim);

            if (dbRehber != null)
            {
                Console.WriteLine(" {0} {1} Lütfen güncellemek istediğiniz kişinin numarasını giriniz.", dbRehber.Isim, dbRehber.Soyisim);
                string yeninumara = Console.ReadLine();
                Console.WriteLine(" {0} {1} isimli kişi rehberden güncellenmek üzere, onaylıyor musunuz ?(y/n)", dbRehber.Isim, dbRehber.Soyisim);
                if (Console.ReadLine() == "y")
                {
                    dbRehber.Numara = yeninumara;
                    Console.WriteLine(" {0} {1} isimli kişi rehberden güncellendi.", dbRehber.Isim, dbRehber.Soyisim);
                    Console.WriteLine(" Güncelleme işlemi başarılı.");
                }
                else
                {
                    Console.WriteLine(" {0} {1} isimli kişi rehberden güncellenmedi.", dbRehber.Isim, dbRehber.Soyisim);
                    Guncelleme();
                }
            }
            else
            {
                Console.WriteLine(" Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine(" * Güncellemeyi sonlandırmak için : (1)");
                Console.WriteLine(" * Yeniden denemek için           : (2)");
                string secim = Console.ReadLine();
                switch (secim)
                {
                    case "1":
                        break;
                    case "2":
                        Guncelleme();
                        break;
                    default:
                        Console.WriteLine(" Lütfen geçerli bir işlem seçiniz.");
                        Guncelleme();
                        break;
                }
            }
        }

        public static void Listeleme()
        {
            Console.WriteLine(" ");
            Console.WriteLine(" Telefon Rehberi");
            Console.WriteLine(" **********************************************");

            Database.GetAll().ForEach(r => Console.WriteLine(r));
        }

        public static void Arama()
        {
            Console.WriteLine(" Arama yapmak istediğiniz tipi seçiniz.");
            Console.WriteLine(" **********************************************");
            Console.WriteLine(" ");
            Console.WriteLine(" İsim veya soyisime göre arama yapmak için: (1)");
            Console.WriteLine(" Telefon numarasına göre arama yapmak için: (2)");
            string secim = Console.ReadLine();
            switch (secim)
            {
                case "1":
                    Console.WriteLine(" Lütfen arama yapmak istediğiniz kişinin adını ya da soyadını giriniz: ");
                    string isim = Console.ReadLine();
                    if (isim == "")
                    {
                        Console.WriteLine(" Lütfen bir isim giriniz.");
                    }
                    else
                    {
                        Rehber dbRehber = Database.GetByName(isim);

                        if (dbRehber != null)
                        {
                            Console.WriteLine(" Arama Sonuçlarınız:");
                            Console.WriteLine(" **********************************************");
                            Console.WriteLine(" ");
                            Console.WriteLine(dbRehber);

                        }
                        else
                        {
                            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                            Console.WriteLine("* Arama işlemini sonlandırmak için : (1)");
                            Console.WriteLine("* Yeniden denemek için             : (2)");
                            string secim2 = Console.ReadLine();
                            switch (secim2)
                            {
                                case "1":
                                    SecimAraci();
                                    break;
                                case "2":
                                    Arama();
                                    break;
                                default:
                                    Console.WriteLine("Lütfen geçerli bir işlem seçiniz.");
                                    break;
                            }
                        }
                    }
                    break;
                case "2":
                    Console.WriteLine(" Lütfen arama yapmak istediğiniz kişinin telefon numarasını giriniz: ");
                    string numara = Console.ReadLine();
                    if (numara == "")
                    {
                        Console.WriteLine(" Lütfen bir numara giriniz.");
                    }
                    else
                    {
                        foreach (Rehber rehber in Database.GetAll())
                        {
                            if (rehber.Numara == numara)
                            {
                                Console.WriteLine(" Arama Sonuçlarınız:");
                                Console.WriteLine(" **********************************************");
                                Console.WriteLine(" ");
                                Console.WriteLine(rehber);
                            }
                            else
                            {
                                Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                                Console.WriteLine("* Arama işlemini sonlandırmak için : (1)");
                                Console.WriteLine("* Yeniden denemek için             : (2)");
                                string secim2 = Console.ReadLine();
                                switch (secim2)
                                {
                                    case "1":
                                        SecimAraci();
                                        break;
                                    case "2":
                                        Arama();
                                        break;
                                    default:
                                        Console.WriteLine("Lütfen geçerli bir işlem seçiniz.");
                                        break;
                                }
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine(" Lütfen geçerli bir işlem seçiniz.");
                    break;
            }
        }
        
    }
}