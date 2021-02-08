using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DbFirst.Models
{
    public partial class TblUser
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public int Password { get; set; }
    }
}
