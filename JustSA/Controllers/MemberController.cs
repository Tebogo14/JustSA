using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Just.Entityframeworkcore.EntityFramework;
using Just.Entityframeworkcore.Models;
using JustSA.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JustSA.Dtos;

namespace JustSA.Controllers
{
    [ApiController]
    [Route("Member")]
    public class MemberController : Controller 
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        [HttpPost]
        [Route("AddMember")]
        public void AddMemberSport(MemberDto memberDto)
        {
            var config = new MapperConfiguration(cfg =>
               cfg.CreateMap<MemberDto, Member>());
            var mapper = new Mapper(config);

            var member  = mapper.Map<Member>(memberDto);
            _memberService.AddMemberSport(member , memberDto.SportId);
        }

        [HttpGet]
        [Route("GetMembers")]
        public List<MemberListDto> GetMembers()
        {
            var member = _memberService.GetMembers();

            var config = new MapperConfiguration(cfg =>
                          cfg.CreateMap<Member, MemberListDto>());
            var mapper = new Mapper(config);

            return mapper.Map<List<MemberListDto>>(member);
        }

        [HttpGet]
        [Route("GetMembersSport")]
        public List<MemberSportListDto> GetMembersSport(int memberId)
        {
            var memberSport = _memberService.GetMembersSport(memberId);

            var config = new MapperConfiguration(cfg =>
                          cfg.CreateMap<Sport, MemberSportListDto>());
            var mapper = new Mapper(config);

            return mapper.Map<List<MemberSportListDto>>(memberSport);
        }

        [HttpPost]
        [Route("AddSport")]
        public void AddSport(SportDto sportDto)
        {
            var config = new MapperConfiguration(cfg =>
               cfg.CreateMap<SportDto, Sport>());
            var mapper = new Mapper(config);

            var sport = mapper.Map<Sport>(sportDto);
            _memberService.AddSport(sport);
        }

        [HttpGet]
        [Route("GetAllSport")]
        public List<MemberSportListDto> GetAllSport()
        {
            var sports = _memberService.GetAllSport();

            var config = new MapperConfiguration(cfg =>
                          cfg.CreateMap<Sport, MemberSportListDto>());
            var mapper = new Mapper(config);

            return mapper.Map<List<MemberSportListDto>>(sports);
        }
    }
}
