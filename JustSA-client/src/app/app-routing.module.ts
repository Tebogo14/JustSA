import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddMemberSportComponent } from './add-member-sport/add-member-sport.component';
import { AddSportComponent } from './add-sport/add-sport.component';
import { AppMainComponent } from './app-main/app-main.component';
import { MemberSportListComponent } from './member-sport-list/member-sport-list.component';
import { MemberSportComponent } from './member-sport/member-sport.component';

const routes: Routes = [{
  path: '',component: AppMainComponent,
  children: [
    { path: '', redirectTo: 'memberSport', pathMatch: 'full' },
    { path: 'memberSport/:id', component: MemberSportListComponent },
    { path: 'memberSport', component: MemberSportComponent },
    { path: 'AddSport', component: AddSportComponent },
    { path: 'AddMember', component: AddMemberSportComponent },
  ]
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
