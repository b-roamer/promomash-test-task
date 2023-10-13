import { Component } from '@angular/core';
import { User } from "./models/user";
import { AuthService } from "./services/auth.service";
import {Router} from "@angular/router";


@Component({
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.scss']
})
export class AppComponent {
  user?: User | null;

  constructor(private authService: AuthService, private router: Router) {
    this.authService.user.subscribe(x => this.user = x);
  }

  logout() {
    this.authService.logout();
  }
}
