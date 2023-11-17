
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Coasia.WebApiRestful.Domain.Abstract
{
    public class AuditTable : IAuditTable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedID { get; set; }
        public string? UpdatedID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
