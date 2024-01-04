using Coasia.WebApiRestful.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coasia.WebApiRestful.Domain.Entitys
{
    [Table("Account")]
    public class User:AuditTable
    {
        [Required]
        [StringLength(150)]
        public string UserName { get; set; }
        [Required]
        [StringLength(150)]
        public string Password { get; set; }
        public string Email { get; set; }
        public string DisplayName {  get; set; }
        public DateTime LastLoggedIn { get; set; }
        public DateTime LastLoggedOut { get; set;}
    }
}
