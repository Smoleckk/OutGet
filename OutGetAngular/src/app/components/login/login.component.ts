import { Component, OnInit } from '@angular/core';
import { Login } from 'src/app/models/login';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

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
  responseData:any;

  constructor(private router:Router,private authService:AuthService) { }

  ngOnInit(): void {
  }
  loginUser() {
        this.authService.proceedLogin(this.login)
        .subscribe({
          next:(responseData)=>{
            console.log(responseData);
            localStorage.setItem('token',responseData)
            this.authService.updatemenu.next();
            this.router.navigate(['shipments']).then(() => {
              // window.location.reload();
            });;
          },
          error:(respone)=>{
            console.log(respone);
          }
        })

  }
}
