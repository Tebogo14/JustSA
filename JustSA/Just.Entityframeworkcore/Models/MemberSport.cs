using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Just.Entityframeworkcore.Models
{
    public class MemberSport
    {
        public int MemberId { get; set; }
        public Member Members { get; set; }
        public int SportId { get; set; }
        public Sport Sports { get; set; }
    }
}
