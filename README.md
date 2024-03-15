# nArchitecture-Demo

Bu proje, Clean Architecture İmplementasyonu kullanılarak geliştirilmiştir.
# Projeler

Bu repo, iki farklı proje içerir:

### 1. Core.Packages Projesi

Bu proje, bir backend altyapısı oluşturmak amacıyla geliştirilmiştir. Temel paketler, araçlar ve yapılandırmaları içerir.

### 2. RentACar Projesi

RentACar projesi, Core.Packages altyapısının uygulanmış halidir. Araç kiralama işlemlerini yönetmek için geliştirilmiştir ve temel altyapı olarak Core.Packages projesini kullanır.

## Özellikler

- CQRS (Command Query Responsibility Segregation) kullanımı
- SOLID ve Clean Code Teknikleri ile geliştirilmiş
- Ultra Gelişmiş Senkron ve Asenkron Repository İmplementasyonu
- Dynamic Search İmplementasyonu
- Response Request Pattern odaklı mapping (Automapper)
- Gelişmiş ve best practice odaklı Entity Framework İmplementasyonu
- API implementasyonu
- Extension yazım teknikleri

## Ek Özellikler

Bu projede ayrıca aşağıdaki ek özellikler de uygulanmıştır:

- **Caching Pipeline İmplementasyonu:** Verilerin önbelleğe alınması için bir pipeline oluşturulmuştur.
- **InMemory Cache İmplementasyonu:** Önbellekleme için hafıza üzerinde bir önbellek kullanılmıştır.
- **Redis Cache İmplementasyonu:** Önbellekleme için Redis kullanılarak bir önbellek sağlanmıştır.
- **Logging Pipeline İmplementasyonu:** Loglama için bir pipeline oluşturulmuş ve entegre edilmiştir.
- **Serilog İmplementasyonu:** Loglama için Serilog kütüphanesi kullanılmıştır.
- **Çoklu ve İlişkili Domain Modelleme:** Çeşitli ve karmaşık ilişkilere sahip domain modelleri tasarlanmıştır.
- **Gelişmiş Mapping İmplementasyonu:** Entity ve DTO (Data Transfer Object) arasında gelişmiş ve esnek bir mapping sağlanmıştır.
- **Migration İmplementasyonu:** Veritabanı değişikliklerini yönetmek için migration işlemleri otomatize edilmiştir.
- **İş Kuralı ve Clean Code Yazım Teknikleri:** İş kurallarının ve temiz kod yazım tekniklerinin kullanımı sağlanmıştır.
- **Global Hata Yönetimi:** Uygulama genelinde hata yönetimi için bir mekanizma entegre edilmiştir.
- **Pipeline Yazım Teknikleri:** Genel olarak pipeline tasarım desenleri ve teknikleri kullanılmıştır.
- **Validation Pipeline ile Fluent Validation İmplementasyonu:** Giriş verilerinin doğrulanması için bir pipeline ve Fluent Validation entegrasyonu sağlanmıştır.
- **Transaction Pipeline İle Transactional Operation İmplementasyonu:** İşlemlerin atomik ve transactional olarak yönetilmesi için bir pipeline entegre edilmiştir.

## Kurulum

Projenin kurulumu için aşağıdaki adımları izleyin:

1. Repo'yu klonlayın: `git clone https://github.com/kullanici/proje.git`
2. Proje klasörüne gidin: `cd proje`
3. Bağımlılıkları yükleyin: `npm install` veya `yarn install`



## Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için [LICENSE](LICENSE) dosyasına bakın.
