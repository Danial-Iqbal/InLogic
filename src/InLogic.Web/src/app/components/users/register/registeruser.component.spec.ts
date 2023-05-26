import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisteruserComponent } from './registeruser.component'; 

describe('RegisteruserComponent', () => {
  let component: RegisteruserComponent;
  let fixture: ComponentFixture<RegisteruserComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RegisteruserComponent]
    });
    fixture = TestBed.createComponent(RegisteruserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('form invalid when empty', () => {
    expect(component.form.valid).toBeFalsy();
  });

  it('email field validity', () => {
    let email = component.form.controls['email']; (1)
    expect(email.valid).toBeFalsy(); (2)
  }); 

  it('submitting a form emits a user', () => {
    expect(component.form.valid).toBeFalsy();
    component.form.controls['name'].setValue("test");
    component.form.controls['email'].setValue("test@test.com");
    component.form.controls['password'].setValue("String@123456789");
    component.form.controls['confirmPassword'].setValue("String@123456789");
    expect(component.form.valid).toBeTruthy(); 
  });

});
