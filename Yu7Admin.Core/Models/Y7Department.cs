using System;
using System.Collections.Generic;

namespace Yu7Admin.Core.Models
{
    public partial class Y7Department
    {
        public Y7Department()
        {
            Y7AdminRole = new HashSet<Y7AdminRole>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Pid { get; set; }
        public string Code { get; set; }
        public int? Sort { get; set; }
        public int? IsDelete { get; set; }

        public virtual ICollection<Y7AdminRole> Y7AdminRole { get; set; }
    }
}
