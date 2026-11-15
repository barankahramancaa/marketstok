using System.Data.Common;
using System.Diagnostics;

namespace market_stok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            string filePath = "products.txt";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(";");
                    products.Add(new Product(parts[0], double.Parse(parts[1]), int.Parse(parts[2])));
                }
            }
            Console.WriteLine("1-ÜRÜN EKLE");
            Console.WriteLine("2-ÜRÜNLERİ LİSTELE");
            Console.WriteLine("3-SATIŞ YAP");
            Console.WriteLine("4-STOĞU AZALAN ÜRÜNLER");
            Console.WriteLine("0-KAYDET ÇIK");
            int choice = -1;
            Console.Write("SEÇİMİNİZ:");
            try
            {
                choice = int.Parse(Console.ReadLine());
            }
            catch
            {

                Console.WriteLine("Lütfen sadece sayı girin");
                choice = -1;
            }
            while (choice != 0)
            {
                if (choice == 1)
                {
                    Console.Write("ÜRÜN ADI");
                    string name = Console.ReadLine();
                    Console.Write("FİYAT");
                    double price = double.Parse(Console.ReadLine());
                    Console.Write("STOK");
                    int stock = int.Parse(Console.ReadLine());
                    products.Add(new Product(name, price, stock));
                    Console.WriteLine("ÜRÜN EKLENDİ");

                }
                else if (choice == 2)
                {
                    for (int i = 0; i < products.Count; i++)
                    {
                        Console.Write($"{i + 1}.");
                        products[i].ShowInfo();

                    }
                }
                else if (choice == 3)
                {
                    try
                    {
                        Console.Write("ÜRÜN NUMARASI:");
                        int number = int.Parse(Console.ReadLine());
                        Console.Write("ADET :");
                        int amount = int.Parse(Console.ReadLine());
                        if (amount > products[number - 1].Stock)
                        {
                            Console.WriteLine("YETERSİZ STOK");
                        }
                        else
                        {
                            products[number - 1].Stock -= amount;
                            Console.WriteLine("Satış yapıldı!");
                        }



                    }


                    catch
                    {

                        Console.WriteLine("HATALI GİRİŞ");
                    }
                }
                else if (choice == 4)
                {

                    List<Product> lowStock = products.Where(p => p.Stock < 10).ToList();
                    if (lowStock.Count == 0)
                    {
                        Console.WriteLine("Stoğu azalan ürün yok");
                    }
                    else
                    {


                        foreach (Product item in lowStock)
                        {
                            item.ShowInfo();
                        }






                    }






                }
                Console.WriteLine("1-ÜRÜN EKLE");
                Console.WriteLine("2-ÜRÜNLERİ LİSTELE");
                Console.WriteLine("3-SATIŞ YAP");
                Console.WriteLine("4-STOĞU AZALAN ÜRÜNLER");
                Console.WriteLine("0-KAYDET ÇIK");
                Console.Write("SEÇİMİNİZ:");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch
                {

                    Console.WriteLine("Lütfen sadece sayı girin");
                    choice = -1;
                }





            }
            List<string> saveLines = new List<string>();
            foreach (Product item in products)
            {
                saveLines.Add(item.ToFileLine());

            }
            File.WriteAllLines(filePath, saveLines);
            Console.WriteLine("Kaydedildi. Görüşürüz");
        }
    }
}
class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public Product(string name, double price, int stock)
    {
        Name = name;
        Price = price;
        Stock = stock;



    }
    public void ShowInfo()
    {
        Console.WriteLine($"{Name} -{Price} TL-Stok:{Stock}");
    }
    public string ToFileLine()
    {
        return ($"{Name};{Price};{Stock}");

    }


}