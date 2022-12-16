using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StoreFront.UI.MVC.Models
{
    [Keyless]
    public class ContactViewModel
    {
        [Required(ErrorMessage = "*")]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public string Subject { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "*")]
        public string Message { get; set; }
    }
}
