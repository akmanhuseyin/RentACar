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
    }
}
