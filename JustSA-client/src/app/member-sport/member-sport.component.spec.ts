import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemberSportComponent } from './member-sport.component';

describe('MemberSportComponent', () => {
  let component: MemberSportComponent;
  let fixture: ComponentFixture<MemberSportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MemberSportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MemberSportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
