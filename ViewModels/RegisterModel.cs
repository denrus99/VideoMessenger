using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AuthApp.ViewModels
{
    /* Модель регистрации пользователя с валидацией данных */
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Login")]
        //[Remote(action: "UniqueLogin" controller: "Validation", ErrorMessage = "Login уже занят")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        //[Remote(action: "UniqueEmail", controller: "Validation", ErrorMessage = "Email уже используется")]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Не указан PhoneNumber")]
        //[Remote(action: "UniquePhone", controller: "Validation", ErrorMessage = "PhoneNumber уже используется")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}