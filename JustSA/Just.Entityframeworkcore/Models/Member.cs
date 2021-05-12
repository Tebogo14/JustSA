using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Just.Entityframeworkcore.Models
{
    public class Member 
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<MemberSport> MemberSports { get; set; }
    }
}
