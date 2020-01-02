using System;
using System.Collections.Generic;

namespace Yu7Admin.Domain.Models
{
    public partial class Y7Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AuthKey { get; set; }
        public string AccessToken { get; set; }
        public int? Addtime { get; set; }
        public short? IsDelete { get; set; }
        public int? ExpireTime { get; set; }
        public string Remark { get; set; }
        public string Mobile { get; set; }
    }
}
