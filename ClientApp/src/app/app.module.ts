import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { JwtInterceptor } from "./interceptors/jwt.interceptor";
import { ErrorInterceptor } from "./interceptors/error.interceptor";
import { NgSwitchCase } from "@angular/common";
import { RouterOutlet } from "@angular/router";

import { LoginComponent } from './pages/login/login.component';
import { MatInputModule } from "@angular/material/input";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatButtonModule } from "@angular/material/button";
import { HomeComponent } from "./pages/home/home.component";
import { RegisterComponent } from './pages/register/register.component';
import {MatStepperModule} from "@angular/material/stepper";
import {MatCheckboxModule} from "@angular/material/checkbox";
import {MatSelectModule} from "@angular/material/select";
import {MatTableModule} from "@angular/material/table";

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule,
    NgSwitchCase,
    RouterOutlet,
    MatInputModule,
    MatButtonModule,
    MatStepperModule,
    MatCheckboxModule,
    FormsModule,
    MatSelectModule,
    MatTableModule
  ],
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    RegisterComponent,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
