using System.ComponentModel.DataAnnotations;

namespace TrainingCentersCRM.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
<<<<<<< HEAD
        [Display(Name = "User name")]
=======
        [Display(Name = "Имя пользователя (e-mail)")]
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        public string UserName { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
<<<<<<< HEAD
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
=======
        [Display(Name = "Текущий пароль")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Минимальная длина пароля - {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("NewPassword", ErrorMessage = "Пароль и подтверждение должны совпадать.")]
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
<<<<<<< HEAD
        [Display(Name = "User name")]
=======
        [Display(Name = "Имя пользователя (e-mail)")]
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
<<<<<<< HEAD
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
=======
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
<<<<<<< HEAD
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
=======
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Имя пользователя (e-mail)")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Минимальная длина пароля - {2} символов", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и подтверждение должны совпадать.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "e-mail")]
        [Required]
        public string EMail { get; set; }
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
    }
}
