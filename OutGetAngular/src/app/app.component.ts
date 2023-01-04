import { Component, DoCheck, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements DoCheck {
  displaymenu = false;
  displayadmin=false;

  displayshipments = false;
  currentrole: any;
  displayAccess = true;
  constructor(private authService: AuthService, private route: Router) {}

  ngOnInit(): void {
    this.authService.updatemenu.subscribe((res) => {
      this.authService.DisplayMenu();
    });
    this.displayAccess = this.authService.DisplayMenu();
    this.displayadmin = this.authService.HaveAccess();

  }

  ngDoCheck(): void {
    if (this.route.url == '/login') {
      this.displaymenu = false;
    this.displayadmin = this.authService.HaveAccess();

    } else {
      this.displaymenu = true;
    this.displayadmin = this.authService.HaveAccess();

    }
  }
  logout() {
    localStorage.clear();
    this.route.navigate(['login']);
  }
}
