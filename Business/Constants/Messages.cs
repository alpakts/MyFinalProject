using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
        public static string ProductAlreadyExists { get; internal set; }
        public static string CategoryLimitExceed { get; internal set; }
        public static string  AuthorizationDenied { get; internal set; }
        public static User UserNotFound { get; internal set; }
        public static string UserRegistered { get; internal set; }
        public static User PasswordError { get; internal set; }
        public static string SuccessfulLogin { get; internal set; }
        public static string UserAlreadyExists { get; internal set; }
        public static string AccessTokenCreated { get; internal set; }
    }
}
