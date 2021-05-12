import { Component, OnInit } from '@angular/core';
import { MemberServiceProxy, MemberSportListDto } from 'src/services/JustSaServices';

@Component({
  selector: 'app-add-sport',
  templateUrl: './add-sport.component.html',
  styleUrls: ['./add-sport.component.less']
})
export class AddSportComponent implements OnInit {

  sports: Array<MemberSportListDto> = new Array<MemberSportListDto>();
  selectedSport: any = 0;

  constructor(private memberService: MemberServiceProxy) { }

  ngOnInit(): void {
    this.GetallSport();
  }
  
  GetallSport() {
    this.memberService.getAllSport().subscribe(result => {
      this.sports = result;
    })
  }
}
