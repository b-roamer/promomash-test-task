import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from "./pages/login/login.component";
import {HomeComponent} from "./pages/home/home.component";
import {authGuard} from "./guards/auth.guard";
import {RegisterComponent} from "./pages/register/register.component";

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [authGuard]},
  { path: 'register', component: RegisterComponent },
  { path: 'login', component: LoginComponent },
  { path: '**', redirectTo: '/login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
