using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Coasia.WebApiRestful.Domain.Abstract;

namespace Coasia.WebApiRestful.Domain.Entitys
{
    public class Products:AuditTable
    {
            
        [StringLength(1000)]
        public string Name { get; set; }

        public int QuatityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UnitOnOrder { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Categories Categories { get; set; }
    }
}
