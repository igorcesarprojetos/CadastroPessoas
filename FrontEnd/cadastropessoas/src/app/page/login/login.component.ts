import { Component } from '@angular/core';
import {MatCardModule} from '@angular/material/card';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import { User } from '../../models/user';
import { Router } from '@angular/router';
import { SharedService } from '../../services/shared/shared.service';
import { UserService } from '../../services/user.service';
import { FormsModule } from '@angular/forms';

const modules = [MatCardModule,MatFormFieldModule,MatInputModule, FormsModule]

@Component({
  selector: 'app-login',
  imports: [modules],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  username: string=""
  password: string=""
  mensagemLogin: string=""

  dataSource: User[]=[];

  constructor(private route:Router, private shared:SharedService, private userService: UserService){

  }

  ngOnInit(): void {
      this.dataSource =[]
      this.loaderSource()    
    }
  
    loaderSource() {
      this.userService.getAll().subscribe((response:User[])=>{
        this.dataSource = response;
      });
    }


  btnLogin() {
    if (this.username=="admin"){
      this.mensagemLogin="Correto"
      this.shared.setUserName(this.username)
      this.route.navigate(["home"])      
    }
    else if (this.username!='' && this.username !="admin" && this.dataSource!.length>0){
      let index =this.dataSource.findIndex((item)=>item.login.toLowerCase() == this.username.toLowerCase())
      if(index > -1){
        this.mensagemLogin="Correto"
        this.shared.setUserName(this.username)
        this.route.navigate(["home"])      
      }
      else {
        this.mensagemLogin="Incorreto"
      }     
    }
    else {
      this.mensagemLogin="Incorreto"
    }    
  }

}
