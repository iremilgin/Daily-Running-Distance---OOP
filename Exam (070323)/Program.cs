using System.Drawing;

namespace Exam__070323_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("*****GÜNLÜK KOŞU MESAFENİZİ ÖLÇEN PROGRAMA HOŞGELDİNİZ*****");
            Console.WriteLine(" ");
            ProgramiCalistir();
            
        }


        // Bu metodda kullanıcının girdiği veriye göre atılan adım uzunluğunu santimetre cinsinden alınacaktır. 
        static void AdimUzunluguBul(out int adimUzunlugu)
        {
            while(true)
            {
                
                Console.WriteLine("Lütfen Adımınızı Santimetre(cm) Cinsinden Giriniz: ");
                bool adimSantimetreMi = int.TryParse(Console.ReadLine(), out adimUzunlugu); 

                if(adimSantimetreMi && adimUzunlugu > 0) //Bu kısımda girilen sayının santimetre cinsine uygun olup olmadığı kontrol edilir. Eğer yanlış veri girildiyse kullanıcı yeniden döngünün başına yönlendirilecektir. 
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Gridiğiniz Adım Sayısı Santimetre(cm) Cinsinden Olmalıdır. Lütfen Geçerli Bir Sayı Giriniz.");
                }

            }
            
        }


        // Bu metodda kullanıcıdan bir dakikada attığı adımı girmesi istenecektir. 
        static void AtilanAdimSayisiniBul(out int atilanAdimSayisi)
        {
            while (true) 
            {
                Console.WriteLine("Lütfen Bir Dakikada Attığınız Adım Sayısını Giriniz:");
                bool adimSayisiDogruMu = int.TryParse(Console.ReadLine(), out atilanAdimSayisi);

                if(adimSayisiDogruMu && atilanAdimSayisi > 0 && atilanAdimSayisi <= 130) // Bir dakikada tempolu yürüyüş yapılsa bile atılacak adım sayısının ortalama 130 olduğunu varsayarak kullanıcının girdiği veri bu satırda kontrol edilecektir. 
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Atılan Adım Sayısı Bir Dakika İçerisinde 130'u Geçemez. Lütfen Geçerli Bir Sayı Giriniz.");
                }
            }
        }


        // Bu metodda kullanıcının girdiği saat ve dakika bilgisine göre koşu süresi hesaplanacaktır.
        static void KosuSuresiniBul(out int saat, out int dakika, out int kosuSuresi)
        {
            while (true)
            {
                Console.WriteLine("Koşu Süresini Giriniz (Saat:Dakika):");
                Console.Write("Saat: ");
                bool kontrol = int.TryParse(Console.ReadLine(), out saat);
                Console.Write("Dakika: ");
                bool kontrol2 = int.TryParse(Console.ReadLine(), out dakika);

                if(kontrol && kontrol2 && saat > 0 && saat <= 3 && dakika > 0 && dakika < 60) // Ortalama aralıksız koşma süresi 3 saatten fazla olamayacağı için bu adımda saat ve dakika cinsinden kontrol yapılacaktır. 
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Girilen Veri Değerleri Aralığında Koşu Yapmak Mümkün Değildir. Lütfen Geçerli Bir Değer Giriniz: ");
                }
            }

            kosuSuresi = saat + dakika / 60;
            Console.WriteLine($"Koşu Süreniz:  {kosuSuresi} ");

        }

        // Bu adımda oluşturulan bütün metodlar kullanılarak program çalıştırılacaktır.
        static void ProgramiCalistir()
        {

            int adimUzunlugu, atilanAdimSayisi, saat, dakika, kosuSuresi;
            double mesafe;
            string[] dizi = new string[0];
            int counter = 0;
            string cevap = "Hayır";


            while (cevap == "Hayır")
            {

                Array.Resize(ref dizi, dizi.Length + 1);

                AdimUzunluguBul(out adimUzunlugu);
                AtilanAdimSayisiniBul(out atilanAdimSayisi);
                KosuSuresiniBul(out saat, out dakika, out kosuSuresi);


                mesafe = adimUzunlugu * atilanAdimSayisi * kosuSuresi / 100.0; //Burada bulunan sonuc santimetre cinsinden olduğu için metre cinsine çevrilecektir. 
                Console.WriteLine("Toplam Koşu Mesafeniz: {0} Metre", mesafe);


                dizi[counter] = ($"\n Adım Uzunluğunuz: {adimUzunlugu} \n Attığınız adım sayınız: {atilanAdimSayisi} \n Koştuğunuz Saat/Dakika: {saat} {dakika} \n Koşu Süreniz: {kosuSuresi} \n Mesafeniz: {mesafe} Metre "); // Eğer kullanıcı birden fazla veri girmek isterse, girmiş olduğu her veri bir dizi şeklinde programın sonunda listelenecektir. 
                counter++;

                try
                {
                    Console.WriteLine("\nProgramı Sonlandırmak İstiyor Musunuz?  (Evet/Hayır): \n "); // Kullanıcıya programa devam etmek isteyip istemediği sorulacak. Eğer devam etmek istiyorsa program döngünün başından tekrar başlayacaktır.
                    cevap = Console.ReadLine();
                }
                catch (OutOfMemoryException exp)
                {
                    Console.WriteLine(exp.Message);

                }
                catch (IOException exp)
                {
                    Console.WriteLine(exp.Message);
                }
                catch (ArgumentOutOfRangeException exp)
                {
                    Console.WriteLine(exp.Message);
                }
                catch (Exception exp)
                {
                    Console.WriteLine(exp.Message);
                }
                finally
                {
                    Console.WriteLine("Finally blogu çalışıyor...");
                }

            }

            Console.WriteLine("*** KULLANICI VERİ LİSTESİ ***"); // Buradaki kod birden fazla girilen verileri listeleyecektir.

            foreach (string liste in dizi)
            {
                Console.WriteLine(liste);
            }
        }
    }
}