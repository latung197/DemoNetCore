using System.ComponentModel.DataAnnotations;

namespace Coasia.WebApiRestful.ViewModel
{
    public class Accoutmodel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
