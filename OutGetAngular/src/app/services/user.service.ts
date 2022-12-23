import { Injectable } from '@angular/core';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor() { }

  public getUser():User[]{
    let user = new User();
    user.id = 1;
    user.name="U1"
    user.firstName="U1"
    user.lastName="U1"
    user.place="New York"
    return [user];
  }
}
