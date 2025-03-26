import { Component, OnDestroy, OnInit } from '@angular/core';
import { User } from '../../models/user';
import { UserService } from '../../services/user.service';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';

const modules = [MatCardModule,MatFormFieldModule,MatInputModule, FormsModule, MatTableModule, MatIconModule]

@Component({
  selector: 'app-user',
  imports: [modules],
  templateUrl: './user.component.html',
  styleUrl: './user.component.css'
})
export class UserComponent implements OnInit, OnDestroy {

  dataSource: User[]=[];
  userAdd:User = new User();

  constructor(private userService:UserService){

  }
  

  ngOnInit(): void {
    this.dataSource =[ ]
    this.loaderSource()    
  }

  loaderSource() {
    this.userService.getAll().subscribe((response:User[])=>{
      this.dataSource = response;
    });
  }

  btnDeletar(user: User):void {    
    let index = this.dataSource.findIndex((item)=> item == user)
    this.dataSource.splice(index,1)
    this.dataSource = Array.from(this.dataSource)
    alert("Deletado")
  }
  
  btnSearch(user: User):void {
     //alert("Buscando")
     this.userService.getById(user.id).subscribe((response:User)=>{
      let json = JSON.stringify(response)
      alert(json)      
    });    
  }

  btnSave():void {
    if(this.userAdd.name){      
      this.dataSource.push(this.userAdd)
      this.dataSource = Array.from(this.dataSource)
      alert("Salvo");
    }
  }
  ngOnDestroy(): void {
    this.dataSource = [];
    this.userAdd = new User(); 
  }

}
