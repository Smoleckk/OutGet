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
  GetToken(){
    return localStorage.getItem('token') ||'';
  }

  HaveAccess(){
    var loggintoken = localStorage.getItem('token') ||'';
    var _extractedtoken = loggintoken.split('.')[1];
    var _atodata = atob(_extractedtoken);
    var _finaldata = JSON.parse(_atodata);
    var role = _finaldata[Object.keys(_finaldata)[1]]
    console.log(_finaldata[Object.keys(_finaldata)[1]]);
    if(role=='User'){
      return true;
    }
    alert('You not having access');
    return false;
  }
}
