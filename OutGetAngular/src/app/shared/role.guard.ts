import { Injectable } from '@angular/core';
import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root',
})
export class RoleGuard implements CanActivate {

  constructor(private authService:AuthService,private route:Router) {}

  canActivate() {
    if(this.authService.DisplayMenu())
    return true;
    else{
    this.route.navigate(['']);
      return false;
    }
  }
}
