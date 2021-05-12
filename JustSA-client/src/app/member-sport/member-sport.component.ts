import { Component, OnInit } from '@angular/core';
import { MemberListDto, MemberServiceProxy } from 'src/services/JustSaServices';

@Component({
  selector: 'app-member-sport',
  templateUrl: './member-sport.component.html',
  styleUrls: ['./member-sport.component.less']
})
export class MemberSportComponent implements OnInit {

  constructor(private memberService: MemberServiceProxy) { }

  members: Array<MemberListDto> = Array<MemberListDto>();

  ngOnInit(): void {
    this.getMember();
  }

  getMember()
  {
     this.memberService.getMembers().subscribe(result => {
       this.members = result;
     })
  }

}
