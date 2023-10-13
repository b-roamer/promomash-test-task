import {inject} from "@angular/core";
import {AuthService} from "../services/auth.service";
import {Router} from "@angular/router";

export const authGuard = () => {
  const router = inject(Router);
  const authService = inject(AuthService);

  if (authService.userValue) {
    return true;
  }

  router.navigate(['/login']);
  return false;
};
