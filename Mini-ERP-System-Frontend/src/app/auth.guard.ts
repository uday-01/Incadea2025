import { CanActivateFn, Router, ActivatedRouteSnapshot } from '@angular/router';
import { inject } from '@angular/core';
import { AuthService } from './services/auth.service';

export const authGuard: CanActivateFn = (route: ActivatedRouteSnapshot, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);


  if (!authService.isLoggedIn()) {

    router.navigate(['/']);
    return false;
  }

  const userRole = authService.getUserRole();
  const allowedRoles = route.data['allowedRoles'] as string[];



  if (!allowedRoles || allowedRoles.includes(userRole)) {

    return true;
  } else {

    router.navigate(['/']);
    return false;
  }
};
