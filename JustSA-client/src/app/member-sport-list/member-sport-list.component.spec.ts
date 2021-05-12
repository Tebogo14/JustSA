import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MemberSportListComponent } from './member-sport-list.component';

describe('MemberSportListComponent', () => {
  let component: MemberSportListComponent;
  let fixture: ComponentFixture<MemberSportListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MemberSportListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MemberSportListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
