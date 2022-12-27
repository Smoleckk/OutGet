import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http: HttpClient) {}

  proceedLogin(usercred: any) {
    return this.http.post(this.baseApiUrl + '/Auth/login', usercred, {
      responseType: 'text',
    });
  }
  IsLoggedIn() {
    return localStorage.getItem('token')!=null;
  }
}
