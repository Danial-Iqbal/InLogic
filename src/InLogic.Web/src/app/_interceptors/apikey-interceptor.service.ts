import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable, Injector } from "@angular/core";
import { Router } from "@angular/router";
import { environment } from "src/environments/environment";
import { catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

@Injectable()

export class ApiKeyInterceptorService implements HttpInterceptor{

    constructor(private injector: Injector, private router: Router){} 

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>>{

        debugger;
        let apiKey = environment.apiKey;

        let apiKeyReq = req.clone({
            headers: req.headers.set('X-API-KEY', apiKey)
        });

        return next.handle(apiKeyReq).pipe(
            catchError((error: HttpErrorResponse)=>{

                debugger;
                let data = {};

                if(error.error instanceof ErrorEvent){

                    data = {
                        message: `Error code: ${error.status} Message: ${error.message}`
                    }

                } 

                if(error.status == 0 || error.status == 401 || error.status == 403){
                    this.router.navigate(['/403']); 
                }

                return throwError(error);

            })
        );
    }
}