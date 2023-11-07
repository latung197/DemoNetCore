using Coasia.WebApiRestful.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coasia.WebApiRestful.Domain.Entitys
{
    public class Categories:AuditTable
    {
        [StringLength(300)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
