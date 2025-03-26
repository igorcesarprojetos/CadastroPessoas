import { Injectable } from '@angular/core';
import { SharedService } from './shared.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService {

  constructor(private sharedService:SharedService, private router:Router) { }

  canActivate():Observable<boolean>| boolean{
    let logged:boolean = this.sharedService.isAuthenticated()
    if(!logged){
      this.router.navigate(['login'])
    }
    return logged
  }
}
