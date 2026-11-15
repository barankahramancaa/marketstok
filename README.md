# 📦 Market Stok Takip

C# ile yazılmış, verileri dosyada kalıcı olarak saklayan bir konsol stok takip uygulaması. Program kapatılıp açıldığında ürünler kaybolmaz.

## Özellikler
- Ürün ekleme (ad, fiyat, stok)
- Ürünleri listeleme
- Satış yapma (stoktan düşme, yetersiz stok kontrolü)
- Stoğu azalan ürünleri listeleme (10 adetten az)
- Çıkışta verileri otomatik kaydetme, açılışta geri yükleme

## Kullanılan teknikler

| Teknik | Projede nerede? |
|---|---|
| **OOP** | `Product` class'ı: property, constructor, `ShowInfo` ve `ToFileLine` metotları |
| **Dosya işlemleri** | `File.Exists`, `File.ReadAllLines`, `File.WriteAllLines` |
| **Veri dönüştürme** | `Split(';')` ile satırı parçalama, `double.Parse` / `int.Parse` |
| **LINQ** | Stoğu azalan ürünler için `Where(p => p.Stock < 10)` |
| **try-catch** | Hatalı giriş ve olmayan ürün numarasında program çökmüyor |

## Dosya formatı

Veriler `products.txt` dosyasında, her satır bir ürün olacak şekilde saklanır:
