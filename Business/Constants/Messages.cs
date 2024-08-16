using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public abstract class Messages
    {
        public static string CarAdded = "Ürün eklendi";
        public static string CarNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Ürünler listelendi";
        internal static string CarPriceInvalid="Ürün fiyatı sıfırdan büyük olmalı";
        internal static string CarNotAvailable="Araç mevcut değil";
        internal static string RentalAdded="Araç Kiralandı";
    }
}
