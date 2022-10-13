using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domains.Base;

namespace Catalog.Domains.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}
