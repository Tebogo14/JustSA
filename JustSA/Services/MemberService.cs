using Just.Entityframeworkcore.EntityFramework;
using Just.Entityframeworkcore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JustSA.Services
{
    public class MemberService : IMemberService
    {
        private readonly JustDbContext _context;

        public MemberService(JustDbContext context)
        {
            _context = context;
        }

        public void AddMemberSport(Member member, int sportId)
        {
            var existmember = _context.Members.Include(x => x.MemberSports).FirstOrDefault(x => x.Name == member.Name && x.Surname == member.Surname);

            if (existmember == null)
            {
                var memberSport = new MemberSport
                {
                    Members = member,
                    SportId = sportId
                };

                _context.MemberSports.Add(memberSport);
            }
            else
            {
                if (existmember.MemberSports.FirstOrDefault(x => x.SportId == sportId) == null)
                {
                    existmember.MemberSports.Add(new MemberSport { MemberId = existmember.Id, SportId = sportId });
                }
                else
                {
                    throw new Exception("Member " + existmember.Name + " " + existmember.Surname + " is already add for" + _context.Sports.FirstOrDefault(x => x.Id == sportId).Name);
                }
            }
            _context.SaveChanges();
        }

        public List<Member> GetMembers()
        {
            return _context.Members.ToList();
        }

        public List<Sport> GetMembersSport(int memberId)
        {
            return _context.MemberSports.Where(x => x.MemberId == memberId).Select(x => x.Sports).ToList();
        }

        public void AddSport(Sport sport)
        {
            var existSport = _context.Sports.FirstOrDefault(x => x.Name == sport.Name);
            
            if(existSport == null)
            {
                _context.Sports.Add(sport);
            }

            _context.SaveChanges();
        }

        public List<Sport> GetAllSport()
        {
            return _context.Sports.ToList();
        }
    }
}
