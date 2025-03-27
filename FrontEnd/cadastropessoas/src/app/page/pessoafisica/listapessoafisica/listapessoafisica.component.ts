import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { PessoaFisica } from '../../../models/pessoafisica';
import { PessoaFisicaService } from '../../../services/pessoafisica.service';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { DatePipe } from '@angular/common';
import { NgxMaskPipe} from 'ngx-mask';


const modules = [MatCardModule,MatFormFieldModule,MatInputModule, MatTableModule, MatIconModule, MatButtonModule]

@Component({
  selector: 'app-listapessoafisica',
  imports: [modules,DatePipe,NgxMaskPipe],
  templateUrl: './listapessoafisica.component.html',
  styleUrl: './listapessoafisica.component.css'
})

export class ListaPessoaFisicaComponent implements OnInit {  

  dataSource: PessoaFisica[]=[];  

  constructor(private pessoaFisicaService:PessoaFisicaService, private router:Router)
  {
    
  }

  ngOnInit(): void {
    this.dataSource=[]    
    this.loadGridPF()
  }

  btnDeletar(pessoaFisica: PessoaFisica) {
    this.pessoaFisicaService.deletePessoaFisica(pessoaFisica);
  }

  btnSearch(pessoaFisica: PessoaFisica) {
    if(pessoaFisica!=null && pessoaFisica.id>0){
      this.pessoaFisicaService.getById(pessoaFisica.id).subscribe((response:PessoaFisica)=>{

      });
    }
  }

  loadGridPF(){
    return this.pessoaFisicaService.getAll().subscribe((response:PessoaFisica[])=>{
      this.dataSource=response
    }); 
  }

  AddPF() {
    this.router.navigate(["pessoafisica/cadastro"]) 
  }
}


