import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MemberDto, MemberServiceProxy, MemberSportListDto, SportDto } from 'src/services/JustSaServices';

@Component({
  selector: 'app-add-member-sport',
  templateUrl: './add-member-sport.component.html',
  styleUrls: ['./add-member-sport.component.less']
})
export class AddMemberSportComponent implements OnInit {

  member: MemberDto = new MemberDto();
  sports: Array<MemberSportListDto> = new Array<MemberSportListDto>();
  selectedSport: any = 0;

  constructor(private memberService: MemberServiceProxy,
    private route: Router) { }

  ngOnInit(): void {
    this.GetallSport();
  }

  save() {
    console.log(this.member);

    this.memberService.addMemberSport(this.member).subscribe(() => {
      this.route.navigate(["/"]);
    })
  }

  GetallSport() {
    this.memberService.getAllSport().subscribe(result => {
      this.sports = result;
    })
  }


}
