import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMemberSportComponent } from './add-member-sport.component';

describe('AddMemberSportComponent', () => {
  let component: AddMemberSportComponent;
  let fixture: ComponentFixture<AddMemberSportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddMemberSportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddMemberSportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
