import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  //baseUrl: string= 'https://jsonplaceholder.typicode.com'
  baseUrl: string= 'http://localhost:3000/usuarios'

  constructor(private  http:HttpClient) { }

  //Get /users/1
  getById(id:number):Observable<User>{
    return this.http.get<User>(`${this.baseUrl}/users/${id}`)
  }

  //Get /users
  getAll():Observable<User[]>{
    //return this.http.get<User[]>(`${this.baseUrl}/users`)
    return this.http.get<User[]>(`${this.baseUrl}/usuarios`)
  }
  
  //Post /users
  addUser(user:User):Observable<User>{
    return this.http.post<User>(`${this.baseUrl}/users`,user)
  }

  //Put /users/1
  updateUser(id:number,user:User):Observable<User>{
    return this.http.put<User>(`${this.baseUrl}/users/${id}`,user)
  }

  //Patch /users/1
  updatePatchUser(id:number,user:User):Observable<User>{
    return this.http.patch<User>(`${this.baseUrl}/users/${id}`,user)
  }

  //Delete /users/1
  deleteUser(user:User):Observable<any>{
    return this.http.delete(`${this.baseUrl}/users/${user.id}`)
  }
}
