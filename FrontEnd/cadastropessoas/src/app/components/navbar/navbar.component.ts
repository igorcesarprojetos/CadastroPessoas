import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import { Subscription } from 'rxjs';
import { SharedService } from '../../services/shared/shared.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';


const modules = [MatToolbarModule,MatIconModule,CommonModule]

@Component({
  selector: 'app-navbar',
  imports: [modules],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavBarComponent implements OnChanges {

  @Input() Drawer:any;
  @Input() IsAuth!:boolean;
  usuarioLogado:string=""

  subscription !: Subscription

  constructor(private shared:SharedService , private router: Router){
   
  }  
  ngOnChanges(changes: SimpleChanges): void {
    this.mostrarUserLogado();
  }
  

  mostrarUserLogado(){
       this.subscription = this.shared.getUserName().subscribe((retorno:string)=>{
      this.usuarioLogado = retorno;
    });
  }

  showMenu() {
    this.Drawer.toggle();
  }

  logout() {
    this.shared.setUserName("");
    this.subscription.unsubscribe()
    let logged:boolean = this.shared.isAuthenticated()
    if(!logged){
      this.router.navigate(['login'])
    }
  } 

}
