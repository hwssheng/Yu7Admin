using System;
using System.Collections.Generic;

namespace Yu7Admin.Core.Models
{
    public partial class Y7Admin
    {
        public Y7Admin()
        {
            Y7AdminRole = new HashSet<Y7AdminRole>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AuthKey { get; set; }
        public string AccessToken { get; set; }
        public int? Addtime { get; set; }
        public short? IsDelete { get; set; }
        public long? ExpireTime { get; set; }
        public string Remark { get; set; }
        public string Mobile { get; set; }

        public virtual ICollection<Y7AdminRole> Y7AdminRole { get; set; }
    }
}
