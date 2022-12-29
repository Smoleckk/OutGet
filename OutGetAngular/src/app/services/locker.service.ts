import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Locker } from '../models/locker';

@Injectable({
  providedIn: 'root'
})
export class LockerService {

  baseApiUrl: string = environment.baseApiUrl;

  constructor(private http:HttpClient) { }

  getAllLocker():Observable<Locker[]>{
    return this.http.get<Locker[]>(this.baseApiUrl+'/Locker');
  }
  addLocker(addLockerRequest:Locker): Observable<Locker>{
    return this.http.post<Locker>(this.baseApiUrl+'/Locker',addLockerRequest )
   }
}
