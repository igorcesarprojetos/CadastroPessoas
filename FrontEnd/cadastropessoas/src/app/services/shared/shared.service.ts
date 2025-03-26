import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  private _username:BehaviorSubject<string> = new BehaviorSubject<string>('') 
  constructor() { }

  isAuthenticated(){
    let user = this._username.getValue()
    if (user) {
      return true;      
    }else{
      return false;
    }
  }

  setUserName(username:string){
    this._username.next(username);
  }

  getUserName(){
    return this._username.asObservable();
  }
}
