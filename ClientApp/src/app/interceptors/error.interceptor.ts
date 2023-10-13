import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from "../services/auth.service";
import { Router } from "@angular/router";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService, private router: Router) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(err => {
      switch (err.status) {
        case 401:
          this.authService.logout();
          this.router.navigate(['/login']);
          break;

        default:
          break;
      }

      console.log(err);

      const error = err.error.Message || err.statusText;
      return throwError(error);
    }))
  }
}
