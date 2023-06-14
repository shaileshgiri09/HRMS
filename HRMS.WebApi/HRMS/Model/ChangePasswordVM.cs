using System.ComponentModel.DataAnnotations;

namespace HRMS.Model
{
    public class ChangePasswordVM
    {
        [Required(ErrorMessage = "Email can't be blank")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Email can't be blank")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}
