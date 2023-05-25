import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AccessrestrictedComponent } from './accessrestricted.component';

describe('AccessrestrictedComponent', () => {
  let component: AccessrestrictedComponent;
  let fixture: ComponentFixture<AccessrestrictedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AccessrestrictedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AccessrestrictedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
