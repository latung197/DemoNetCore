
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Coasia.WebApiRestful.Domain.Abstract
{
    public class AuditTable : IAuditTable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set ; }
        public bool IsActive { get ; set; }
    }
}
