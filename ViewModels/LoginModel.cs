using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AuthApp.ViewModels
{
    /* Модель регистрации пользователя с валидацией данных */
    public class LoginModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [Remote(action: "ExistEmail", controller: "Validation", ErrorMessage = "Login уже занят")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }
    }
}