using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coasia.WebApiRestful.Domain.Abstract
{
    public interface IAuditTable
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedID { get; set; }
        public string UpdatedID { get; set;}
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
