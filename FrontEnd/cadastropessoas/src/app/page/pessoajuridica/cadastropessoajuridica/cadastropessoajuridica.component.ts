import { PessoaJuridica } from './../../../models/pessoajuridica';
import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';
import { NgxMaskDirective} from 'ngx-mask';
import { Router } from '@angular/router';
import { PessoaJuridicaService } from '../../../services/pessoajuridica.service';

const modules = [MatCardModule,MatFormFieldModule,MatInputModule, FormsModule]

@Component({
  selector: 'app-cadastropessoajuridica',
  imports: [modules,NgxMaskDirective],
  templateUrl: './cadastropessoajuridica.component.html',
  styleUrl: './cadastropessoajuridica.component.css'
})
export class CadastroPessoaJuridicaComponent implements OnInit, OnDestroy {

  pessoaJuridica:PessoaJuridica = new PessoaJuridica();
  mascaraCNPJ :string ="00.000.000/0000-00";

  constructor (public pessoaJuridicaService : PessoaJuridicaService ,private route: Router){

  }
  
  ngOnInit(): void {
   
  }

  ngOnDestroy(): void {
    
  }


  btnSalvar() {        
      this.pessoaJuridicaService.addPessoaJuridica(this.pessoaJuridica).subscribe(
        { 
          next:(response:PessoaJuridica)=> {
            console.log(response)
            this.route.navigateByUrl("pessoajuridica/lista")
          },      
          error: (error) => {
            console.log(error)
          } 
      });
    }

}
