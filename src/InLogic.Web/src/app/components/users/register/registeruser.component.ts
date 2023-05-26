import { Component, OnDestroy, OnInit} from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UsersService } from 'src/app/_services/users.service';
import {Router, ActivatedRoute} from '@angular/router';
import { HttpErrorResponse } from '@angular/common/http';
import {SubSink} from 'subsink';  
import { PasswordRegix, passwordMatchValidator } from 'src/app/_core/common';
import { Alert } from 'src/app/_models/alert.mode.';  

@Component({
  selector: 'app-registeruser',
  templateUrl: './registeruser.component.html',
  styleUrls: ['./registeruser.component.css']
})
export class RegisteruserComponent implements OnInit, OnDestroy{

  subs = new SubSink();  
  form!: FormGroup;
  alerts: Alert[] = [];
  spinner:boolean = false; 

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private UsersService : UsersService) { }

  ngOnInit() {
    this.formValidation()
  }

  onSubmit() { 
    if (this.form.valid) {
      this.spinner = true;
      this.registerUser()
    } else { 
      this.alerts.push({
        type: 'danger',
        msg: 'Please fill form with valid data',
        timeout: 3000
      })
    }
  }

  formValidation(){
    this.form = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email, Validators.maxLength(256)]],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(30), Validators.pattern(PasswordRegix)]],
      confirmPassword: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(30), Validators.pattern(PasswordRegix)]]
    }, { validator: passwordMatchValidator });
  }

  getErrorMessages(controlName: string): string[] {
    const control = this.form.get(controlName);
    const errorMessages: string[] = [];

    if (control && control.errors) {
      if (control.errors['required']) {
        errorMessages.push('This field is required.');
      }
      if (control.errors['pattern']) {
        const patternMessage = this.getPatternErrorMessage(control.errors['pattern'].requiredPattern);
        errorMessages.push(patternMessage);
      }
      if (control.errors['minlength']) {
        errorMessages.push(`Minimum length is ${control.errors['minlength'].requiredLength}.`);
      }
      if (control.errors['maxlength']) {
        errorMessages.push(`Maximum length is ${control.errors['maxlength'].requiredLength}.`);
      }
      if (control.errors['passwordMismatch']) {
        errorMessages.push('Passwords do not match.');
      }
    }

    return errorMessages;
  }

  getPatternErrorMessage(pattern: string): string {
    if (pattern === '^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-zd$@$!%*?&].{8,30}$') {
      return 'Password must contain at least one uppercase letter, one lowercase letter, one digit, one special character, and be 8-30 characters long.';
    }

    return 'Invalid format.';
  }

  onClosed(dismissedAlert: Alert): void {
    this.alerts = this.alerts.filter(alert => alert !== dismissedAlert);
  }


  registerUser() {
    this.subs.add(
      this.UsersService.registerUser(this.form.value).subscribe({
        next: (data: any) => {
          this.spinner = false;
          this.setAlert('successfully added', 'success')
          setTimeout(() => {
            this.form.reset();
            this.router.navigate(['/user/register']);
          }, 4000);
        },
        error: (err: HttpErrorResponse) => {
          this.spinner = false;
          this.setAlert(err.error.title, 'danger');
        }
      })
    );
  }

  private  setAlert(msg:string, type:'danger'|'success'){
    this.alerts.push({
      msg:msg,
      type:type,
      timeout:3000
    })
  }
    ngOnDestroy(): void {
    this.subs.unsubscribe();
  }

  onReset(){
    this.form.reset();
  }
  
}
