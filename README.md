# Akıllı Randevu Sistemi

Bu proje, işletmelerin ve müşterilerin randevu yönetimini kolaylaştıran bir web API ve mobil uygulama içerir.

## Teknolojiler

### Backend (ASP.NET Core Web API)
- ASP.NET Core 7.0
- MongoDB
- JWT Authentication
- Repository Pattern

### Mobile (Android)
- Java
- Android Studio
- REST API Integration

## Özellikler

### Kullanıcı Yönetimi
- Müşteri ve İşletme kaydı
- JWT tabanlı kimlik doğrulama
- Rol tabanlı yetkilendirme

### Randevu İşlemleri
- Randevu oluşturma
- Randevu güncelleme
- Randevu iptal etme
- Randevu listeleme
- Tarih bazlı filtreleme

### İşletme Yönetimi
- İşletme profili oluşturma
- Çalışma saatleri yönetimi
- Hizmet listesi yönetimi
- Randevu takibi

## Kurulum

### Backend
1. MongoDB'yi yükleyin ve çalıştırın
2. Projeyi klonlayın
3. `appsettings.json` dosyasındaki MongoDB bağlantı ayarlarını güncelleyin
4. Projeyi çalıştırın:
```bash
cd AkilliRandevuAPI
dotnet run
```

### Mobile
1. Android Studio'yu yükleyin
2. Projeyi klonlayın
3. `appsettings.json` dosyasındaki API URL'ini güncelleyin
4. Projeyi Android Studio'da açın ve çalıştırın

## API Dokümantasyonu

API endpoint'leri ve kullanımları hakkında detaylı bilgi için Swagger UI'ı kullanabilirsiniz:
```
https://localhost:5001/swagger
```

## Lisans

Bu proje MIT lisansı altında lisanslanmıştır. 