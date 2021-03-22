using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        // Brand things.
        public static string BrandAdded = "Marka Eklendi.";
        public static string BrandDeleted = "Marka Silindi.";
        public static string BrandUpdated = "Marka Güncellendi.";
        public static string BrandListed = "Markalar listelendi.";
        public static string BrandNameInvalid = "Marka ismi geçersiz.";

        // Color things.
        public static string ColorAdded = "Renk Eklendi.";
        public static string ColorDeleted = "Renk Silindi.";
        public static string ColorUpdated = "Renk Güncellendi.";
        public static string ColorListed = "Renkler listelendi.";
        public static string ColorNameInvalid = "Renk ismi geçersiz.";

        // Car things.
        public static string CarAdded = "Araba Eklendi.";
        public static string CarDeleted = "Araba Silindi.";
        public static string CarUpdated = "Araba Güncellendi.";
        public static string CarListed = "Arabalar listelendi.";
        public static string CarDailyPriceInvalid = "Araba günlük ücreti geçersiz.";
        public static string GetSuccessCarMessage = "Araç bilgisi / bilgileri getirildi.";
        public static string GetErrorCarMessage = "Araç bilgisi / bilgileri getirilemedi.";

        // CarImage things.
        public static string CarImageAdded = "Araba resmi Eklendi.";
        public static string CarImageDeleted = "Araba resmi Silindi.";
        public static string CarImageUpdated = "Araba resmi Güncellendi.";
        public static string CarImageListed = "Araba resimleri listelendi.";
        public static string CarImageLimitExceded = "Resim limiti aşıldığı için yeni resim eklenemiyor.";

        // Auth things.
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Şifre hatalı.";
        public static string SuccessfulLogin = "Sisteme giriş başarılı.";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut.";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi.";
        public static string AccessTokenCreated = "Token oluşturuldu.";
        public static string AuthorizationDenied = "Yetkiniz yok.";

        //CarImage

        public static string AddCarImageMessage = "Araç resmi başarıyla eklendi";
        public static string EditCarImageMessage = "Araç resmi başarıyla güncellendi";
        public static string DeleteCarImageMessage = "Araç resmi başarıyla silindi";
        public static string AboveImageAddingLimit = "Araç maksimum resim sayısına ulaştı. Resim ekleyemezsiniz";
        public static string IncorrectFileExtension = "Kabul edilmeyen dosya uzantısı";
        public static string ImageNotFound = "Resim dosyası bulunamadı.";
        public static string CarImageNotFound = "Değiştirilmek istenen resim bulunamadı.";

        //Rental
        public static string AddRentalMessage = "Araç kiralama işlemi başarıyla eklendi.";

        public static string DeleteRentalMessage = "Araç kiralama işlemi başarıyla silindi.";
        public static string EditRentalMessage = "Araç kiralama işlemi başarıyla güncellendi.";
        public static string GetSuccessRentalMessage = "Araç kiralama işlemi bilgisi / bilgileri getirildi.";
        public static string GetErrorRentalMessage = "Araç kiralama işlemi bilgisi / bilgileri getirilemedi.";
        public static string CarAvaible = "Araç kiralanmaya uygundur.";
        public static string CarNotAvaible = "Araç kiralanmaya uygun değildir.";
        public static string CarNotDeliverTheCar = "Araç teslim almaya uygun değildir.";
        public static string CarDeliverTheCar = "Araç teslim alındı.";
        public static string ErrorRentalFKMessage = "Müşteri ve araba alanlarını tekrar kontrol ediniz..";

        public static string InsufficientBalance = "Yetersiz bakiye";
        public static string PaymentCompleted = "Ödeme yapıldı";


    }
}
