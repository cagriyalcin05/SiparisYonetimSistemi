/*
    Proje: Sipariş Yönetim Sistemi
    Geliştirici: ibrahim Çağrı Yalçın
    Açıklama: Konsol tabanlı, JSON destekli sipariş yönetim uygulaması.
    Tarih: 2026
*/
using System.Text.Json;
using System.IO;
using System;
using System.Collections.Generic;

class Program
{
    const string SepetDosyaYolu = "sepet.json";
    const string MenuDosyaYolu = "menu.json";
    public class CartItem
    {
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }

    static void Main()
    {
        Menu? menu = LoadMenu(MenuDosyaYolu);

        if (menu == null)
        {
            return;
        }

        List<Product> sepet;

        if (File.Exists(SepetDosyaYolu))
        {
            string sepetJson = File.ReadAllText(SepetDosyaYolu);
            sepet = JsonSerializer.Deserialize<List<Product>>(sepetJson) ?? new List<Product>();
        }
        else
        {
            sepet = new List<Product>();
        }

        bool calisiyor = true;

        while (calisiyor)


        {
            Console.Clear();
            Console.WriteLine("=== SİPARİŞ YÖNETİM SİSTEMİ ===");
            Console.WriteLine("------------------------------");
            Console.WriteLine("1 - Menü Göster");
            Console.WriteLine("2 - Sipariş Ver");
            Console.WriteLine("3 - Siparişleri Listele");
            Console.WriteLine("4 - Sipariş Sil");
            Console.WriteLine("5 - Çıkış");
            Console.WriteLine("6 - Uygulama Hakkında");
            Console.Write("Seçiminiz: ");

            string secim = Console.ReadLine() ?? "";

            switch (secim)
            {
                case "1":
                    Console.WriteLine(menu.RestaurantName);
                    foreach (var category in menu.Categories)
                    {
                        Console.WriteLine("\n" + category.CategoryName);

                        foreach (var product in category.Products)
                        {
                            Console.WriteLine($"{product.Id} - {product.Name} - {product.Price} TL");
                        }
                    }
                    break;

                case "2":
                    SepeteEkle(menu, sepet);   
                    break;

                case "3":
                    SepetiListele(sepet);      
                    break;

                case "4":
                    SepettenSil(sepet);        
                    break;

                case "5":
                    calisiyor = false;
                    Console.WriteLine("Programdan çıkılıyor...");
                    break;

                case "6":
                    Console.WriteLine("=== UYGULAMA HAKKINDA ===");
                    Console.WriteLine("Bu uygulama ibrahim Çağrı Yalçın tarafından geliştirilmiştir.");
                    Console.WriteLine("Konsol tabanlı, JSON destekli sipariş yönetim sistemidir.");
                    Console.WriteLine("2026");
                    break;

                default:
                    Console.WriteLine("Geçersiz seçim!");
                    break;
            }
            Console.WriteLine("\nDevam etmek için bir tuşa basın...");
            Console.ReadKey();


        }
    }
    static void SepetiKaydet(List<Product> sepet)
    {
        string sepetJson = JsonSerializer.Serialize(sepet);
        File.WriteAllText(SepetDosyaYolu, sepetJson);
    }

    static Product? UrunBul(Menu menu, int id)
    {
        foreach (var category in menu.Categories)
        {
            foreach (var product in category.Products)
            {
                if (product.Id == id)
                    return product;
            }
        }
        return null;
    }

    static Menu? LoadMenu(string path)
    {
        try
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<Menu>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("menu.json okunamadı!");
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    static void SepeteEkle(Menu menu, List<Product> sepet)
    {
        Console.WriteLine("Ürün ID giriniz:");

        if (int.TryParse(Console.ReadLine(), out int girilenId))
        {
            Product? secilenUrun = UrunBul(menu, girilenId);

            if (secilenUrun != null)
            {
                sepet.Add(secilenUrun);
                SepetiKaydet(sepet);
                Console.WriteLine($"{secilenUrun.Name} sepete eklendi!");
            }
            else
            {
                Console.WriteLine("Ürün bulunamadı.");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz giriş.");
        }
    }

    static void SepetiListele(List<Product> sepet)
    {
        if (sepet.Count == 0)
        {
            Console.WriteLine("Sepet boş.");
            return;
        }

        double toplam = 0;

        Console.WriteLine("=== SEPET ===");

        foreach (var urun in sepet)
        {
            Console.WriteLine($"{urun.Name} - {urun.Price} TL");
            toplam += urun.Price;
        }

        Console.WriteLine("----------------------");
        Console.WriteLine($"Toplam Tutar: {toplam:F2} TL");
        Console.WriteLine($"Toplam ürün sayısı: {sepet.Count}");
    }

    static void SepettenSil(List<Product> sepet)
    {
        if (sepet.Count == 0)
        {
            Console.WriteLine("Sepet boş.");
            return;
        }

        Console.WriteLine("=== SEPET ===");

        for (int i = 0; i < sepet.Count; i++)
        {
            Console.WriteLine($"{i + 1} - {sepet[i].Name} - {sepet[i].Price} TL");
        }

        Console.Write("Silmek istediğiniz ürün numarası: ");

        if (int.TryParse(Console.ReadLine(), out int silIndex))
        {
            if (silIndex > 0 && silIndex <= sepet.Count)
            {
                sepet.RemoveAt(silIndex - 1);
                SepetiKaydet(sepet);
                Console.WriteLine("Ürün silindi.");
            }
            else
            {
                Console.WriteLine("Geçersiz numara.");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz giriş.");
        }
    }
}