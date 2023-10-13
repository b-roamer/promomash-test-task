import { Component } from '@angular/core';
import {User} from "../../models/user";
import {UserService} from "../../services/user.service";
import {first} from "rxjs/operators";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  users: User[] = [];
  displayedColumns: string[] = ['userId', 'email', 'countryId', 'provinceId'];

  constructor(private userService: UserService) {
    userService.getAll()
      .pipe(first())
      .subscribe(users => {
        this.users = users;
      })
  }
}
