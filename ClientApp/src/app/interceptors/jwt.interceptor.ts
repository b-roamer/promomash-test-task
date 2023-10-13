import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from "../services/auth.service";
import { environment } from "../environments/environment";

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const user = this.authService.userValue;
    const isApiUrl = request.url.startsWith(environment.apiUrl);

    if (user?.accessToken && isApiUrl) {
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${user.accessToken}`
        }
      });
    }

    return next.handle(request);
  }
}
