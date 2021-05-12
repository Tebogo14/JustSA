import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MemberServiceProxy, SportDto } from 'src/services/JustSaServices';

@Component({
  selector: 'app-member-sport-list',
  templateUrl: './member-sport-list.component.html',
  styleUrls: ['./member-sport-list.component.less']
})
export class MemberSportListComponent implements OnInit {

  memberParam:any;
  sports: Array<SportDto> = new Array<SportDto>();

  constructor(private route: ActivatedRoute,private memberService: MemberServiceProxy) { }

  ngOnInit(): void {
    this.memberParam = this.route.snapshot.paramMap.get('id');
    this.GetmemberSport();
  }

  GetmemberSport()
  {
    this.memberService.getMembersSport(this.memberParam).subscribe(result => {
      this.sports = result;
    })
  }

}
