using System;
using System.Collections.Generic;

namespace Yu7Admin.Core.Models
{
    public partial class Y7AdminRole
    {
        public int Id { get; set; }
        public int? AdminId { get; set; }
        public int? DepartmentId { get; set; }
        public int? Role { get; set; }

        public virtual Y7Admin Admin { get; set; }
        public virtual Y7Department Department { get; set; }
    }
}
