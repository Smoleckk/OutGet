import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/models/login';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login: Login = {
    username: '',
    password: '',
  };

  constructor(private router:Router) { }

  ngOnInit(): void {
  }
  loginUser() {
    // this.shipmentsService.addShipment(this.addShipmentRequest).subscribe({
      // next: (shipment) => {
        this.router.navigate(['shipments']);
      // },
    // });
  }
}
