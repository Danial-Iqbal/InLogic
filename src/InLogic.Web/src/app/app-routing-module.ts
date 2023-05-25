import { NgModule } from "@angular/core"; 
import { RouterModule, Routes } from "@angular/router"; 
import { RegisteruserComponent } from "./components/users/register/registeruser.component";  
import { AccessrestrictedComponent } from "./_shared/accessrestricted/accessrestricted.component";

const routes: Routes = [
    {
        path: '',
        redirectTo: 'user/register',
        pathMatch: "full"
    },
    {
        path:'user/register',
        component: RegisteruserComponent

    }, 
    {
        path: '403',
        component: AccessrestrictedComponent

    }, 
    {
        path: '*',
        redirectTo: 'user/register'
    },
    {
        path: 'user/*',
        redirectTo: 'user/register'
    }
]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule{}