import { Injectable } from '@angular/core';
import { PessoaJuridica } from '../models/pessoajuridica';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class PessoaJuridicaService {

  baseUrl= environment.apiUrl;  
  
  constructor(private  http:HttpClient) { }

  //Get /PessoaJuridicas/1
  getById(id:number):Observable<PessoaJuridica>{
    return this.http.get<PessoaJuridica>(`${this.baseUrl}/pessoajuridica/${id}`)
  }

  //Get /PessoaJuridicas
  getAll():Observable<PessoaJuridica[]>{
    return this.http.get<PessoaJuridica[]>(`${this.baseUrl}/pessoajuridica`)
  }
  
  //Post /PessoaJuridicas
  addPessoaJuridica(pessoaJuridica:PessoaJuridica):Observable<PessoaJuridica>{
    return this.http.post<PessoaJuridica>(`${this.baseUrl}/pessoajuridica`,pessoaJuridica)
  }

  //Put /PessoaJuridica/1
  updatePessoaJuridica(id:number,pessoaJuridica:PessoaJuridica):Observable<PessoaJuridica>{
    return this.http.put<PessoaJuridica>(`${this.baseUrl}/pessoajuridica/${id}`,pessoaJuridica)
  }

  //Patch /PessoaJuridica/1
  updatePatchPessoaJuridica(id:number,pessoaJuridica:PessoaJuridica):Observable<PessoaJuridica>{
    return this.http.patch<PessoaJuridica>(`${this.baseUrl}/pessoajuridica/${id}`,pessoaJuridica)
  }

  //Delete /PessoaJuridica/1
  deletePessoaJuridica(pessoaJuridica:PessoaJuridica):Observable<PessoaJuridica>{
    let id: number = pessoaJuridica.Id;
    return this.http.delete<PessoaJuridica>(`${this.baseUrl}/pessoajuridica/${id}`)
  }
}
