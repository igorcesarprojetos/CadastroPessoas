import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PessoaFisica } from '../models/pessoafisica';

@Injectable({
  providedIn: 'root'
})
export class PessoaFisicaService {

   baseUrl= environment.apiUrl;  
  
  constructor(private  http:HttpClient) { }

  //Get /PessoaFisicas/1
  getById(id:number):Observable<PessoaFisica>{
    return this.http.get<PessoaFisica>(`${this.baseUrl}/pessoafisica/${id}`)
  }

  //Get /PessoaFisicas
  getAll():Observable<PessoaFisica[]>{
    return this.http.get<PessoaFisica[]>(`${this.baseUrl}/pessoafisica`)
  }
  
  //Post /PessoaFisicas
  addPessoaFisica(pessoaFisica:PessoaFisica):Observable<PessoaFisica>{
    return this.http.post<PessoaFisica>(`${this.baseUrl}/pessoafisica`,pessoaFisica)
  }

  //Put /PessoaFisica/1
  updatePessoaFisica(id:number,pessoaFisica:PessoaFisica):Observable<PessoaFisica>{
    return this.http.put<PessoaFisica>(`${this.baseUrl}/pessoafisica/${id}`,pessoaFisica)
  }

  //Patch /PessoaFisica/1
  updatePatchPessoaFisica(id:number,pessoaFisica:PessoaFisica):Observable<PessoaFisica>{
    return this.http.patch<PessoaFisica>(`${this.baseUrl}/pessoafisica/${id}`,pessoaFisica)
  }

  //Delete /PessoaFisica/1
  deletePessoaFisica(pessoaFisica:PessoaFisica):Observable<any>{
    return this.http.delete(`${this.baseUrl}/pessoafisica/${pessoaFisica.Id}`)
  }
}
