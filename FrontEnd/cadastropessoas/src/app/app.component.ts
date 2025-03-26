import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { NavBarComponent } from './components/navbar/navbar.component';
import { FooterComponent } from './components/footer/footer.component';
import { MatIconModule } from '@angular/material/icon';
import {MatListModule} from '@angular/material/list';
import {MatSidenavModule} from '@angular/material/sidenav';
import { SharedService } from './services/shared/shared.service';
import { CommonModule } from '@angular/common';

const components = [NavBarComponent,FooterComponent]
const modules = [MatIconModule,MatListModule,MatSidenavModule,CommonModule]
const routers = [RouterOutlet, RouterLink]

@Component({
  selector: 'app-root',
  imports: [components,modules,routers],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'cadastropessoas';
  isAuth:boolean = false

  constructor(private shared:SharedService){

  }

  ngOnInit(): void {
    this.shared.getUserName().subscribe((retorno:string)=>{
      if(retorno){
        this.isAuth = true
      }else{
        this.isAuth = false
      } 
    });
  }
}
