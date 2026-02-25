# 🛒 Sipariş Yönetim Sistemi

Konsol tabanlı bir sipariş yönetim uygulamasıdır.  
C# ve JSON kullanılarak geliştirilmiştir.

---

## 🎯 Proje Amacı

Bu proje;

- C# konsol uygulaması geliştirmeyi  
- JSON dosyası ile veri okuma ve yazma işlemlerini uygulamayı  
- Nesne yönelimli modelleme (CartItem, Product, Category) yapmayı  
- Liste ve koleksiyon yönetimini  
- Metotlara bölünmüş temiz ve okunabilir kod yazmayı  
- Uygulama durumu (state) yönetimini ve kalıcı veri saklamayı  
- Git branch, merge ve versiyonlama (tag) mantığını uygulamayı

öğrenmek amacıyla geliştirilmiştir.

---

## 🚀 Özellikler

- 📋 Menü listeleme (JSON’dan dinamik veri okuma)  
- ➕ Sepete ürün ekleme  
- 🔢 Aynı ürün tekrar eklenirse adet artırma (CartItem & Quantity mantığı)  
- 📦 Sepeti görüntüleme (adet destekli listeleme)  
- ❌ Sepetten ürün silme  
- 🧹 Sepeti tamamen temizleme  
- 💰 Toplam tutar hesaplama (adet x fiyat)  
- 💾 Sepet verisini JSON dosyasına kaydetme  
- 🔁 Uygulama yeniden başlatıldığında sepeti otomatik yükleme   

---

## 🛠️ Kullanılan Teknolojiler

- C#  
- .NET  
- System.Text.Json  
- Git (branch & merge yapısı)  

---

## 📂 Proje Yapısı

```text
SiparisYonetimSistemi/
│
├── Program.cs
├── Menu.cs
├── Category.cs
├── Product.cs
├── menu.json
├── sepet.json (uygulama çalıştığında otomatik oluşturulur)
└── README.md
```

---

## 🔁 Uygulanan Git İşlemleri

Bu projede aşağıdaki Git işlemleri uygulanmıştır:

- Repository oluşturma  
- Ana branch (main) yapısı  
- Feature branch üzerinden geliştirme (feature/cartitem-upgrade)  
- Küçük ve anlamlı commit’ler (feat, chore vb.)  
- Pull Request açma  
- PR üzerinden merge işlemi  
- Versiyon etiketi oluşturma (v1.0, v2.0)  
- Tag’leri remote’a push etme  

---

## 🏷️ Versiyon

v2.0  

### v2.0 Güncellemeleri

- CartItem modeli eklendi  
- Quantity (adet artırma) mantığı eklendi  
- Sepet veri yapısı List<Product> → List<CartItem> olarak güncellendi  
- Toplam tutar hesaplama adet destekli hale getirildi  
- Sepeti tamamen temizleme özelliği eklendi  
- Sepet JSON yapısı güncellendi  
- v2.0 versiyon etiketi oluşturuldu 

---

## ⚙️ Çalıştırma

### 1️⃣ Projeyi klonlayın

```bash
git clone https://github.com/cagriyalcin05/SiparisYonetimSistemi.git
```

### 2️⃣ Visual Studio ile açın  
### 3️⃣ Debug modunda çalıştırın

---

## 👨‍💻 Geliştirici

İbrahim Çağrı Yalçın  
2026
