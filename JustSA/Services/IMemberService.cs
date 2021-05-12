using Just.Entityframeworkcore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustSA.Services
{
    public interface IMemberService 
    {
        public void AddMemberSport(Member member , int SportId);
        public List<Member> GetMembers();
        public List<Sport> GetMembersSport(int memberId);
        public void AddSport(Sport Sport);
        public List<Sport> GetAllSport();
    }
}
