import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {environment} from 'src/environments/environment';
import { user } from '../_models/users.model';

@Injectable({
    providedIn: 'root'
})

export class UsersService{
    
    readonly apiUrl = environment.apiUrl;

    constructor(private http: HttpClient){}

    registerUser(body: user){
        debugger;

        return this.http.post(this.apiUrl + 'Users/Register', body);
    
    }
}