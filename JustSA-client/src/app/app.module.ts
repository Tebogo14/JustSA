import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { AppMainComponent } from './app-main/app-main.component';
import { MemberSportComponent } from './member-sport/member-sport.component';
import { API_BASE_URL, MemberServiceProxy } from 'src/services/JustSaServices';
import { AppConsts } from 'src/AppConsts';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { MyInterceptor } from '../my.interceptor';
import { MemberSportListComponent } from './member-sport-list/member-sport-list.component';
import { AddMemberSportComponent } from './add-member-sport/add-member-sport.component';
import { AddSportComponent } from './add-sport/add-sport.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    AppMainComponent,
    MemberSportComponent,
    MemberSportListComponent,
    AddMemberSportComponent,
    AddSportComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    MemberServiceProxy,
    { provide: API_BASE_URL, useFactory: getRemoteServiceBaseUrl },
    { provide: HTTP_INTERCEPTORS, useClass: MyInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getRemoteServiceBaseUrl(): string {

  return AppConsts.remoteServiceBaseUrl;

}
