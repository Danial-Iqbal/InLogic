import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing-module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
 
// NGX-BOOTSTRAP
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AlertModule } from 'ngx-bootstrap/alert'; 
import { TypeaheadModule } from 'ngx-bootstrap/typeahead';  
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';  
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ToastrModule } from 'ngx-toastr';  

import { AppComponent } from './app.component'; 
import { ApiKeyInterceptorService } from './_interceptors/apikey-interceptor.service'; 
import { RegisteruserComponent } from './components/users/register/registeruser.component';
import { AccessrestrictedComponent } from './_shared/accessrestricted/accessrestricted.component'; 
import { NavigationComponent } from './_core/components/navigation/navigation/navigation.component'; 


@NgModule({
  declarations: [
    AppComponent, 
    RegisteruserComponent,
    AccessrestrictedComponent, 
    NavigationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    AlertModule.forRoot(),
    TabsModule.forRoot(),
    BrowserAnimationsModule,
    TypeaheadModule.forRoot(),
    ToastrModule.forRoot()
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ApiKeyInterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
