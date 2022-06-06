using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "ürün eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz";
        public static string ProductListed = "ürünler lsitelendi";
        public static string MaintanceTime= "Sunucu bakımda";

        public static string InvalidUnitPrice { get; internal set; }
    }
}
