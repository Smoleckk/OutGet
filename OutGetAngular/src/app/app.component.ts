import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  constructor(private authService: AuthService, private route: Router) {}

  ngOnInit(): void {}
  logout() {
    localStorage.removeItem('token');
    this.route.navigate(['login']);
  }
}
