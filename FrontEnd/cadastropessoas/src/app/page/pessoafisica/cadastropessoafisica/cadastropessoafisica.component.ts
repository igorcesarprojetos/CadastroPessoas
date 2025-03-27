import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { PessoaFisica } from '../../../models/pessoafisica';
import { PessoaFisicaService } from '../../../services/pessoafisica.service';
import { FormsModule } from '@angular/forms';
import { NgxMaskDirective} from 'ngx-mask';
import { Router } from '@angular/router';
import { routes } from '../../../app.routes';

const modules = [MatCardModule,MatFormFieldModule,MatInputModule, FormsModule]

@Component({
  selector: 'app-cadastropessoafisica',
  imports: [modules,NgxMaskDirective],
  templateUrl: './cadastropessoafisica.component.html',
  styleUrl: './cadastropessoafisica.component.css'
})
export class CadastroPessoaFisicaComponent implements OnInit, OnDestroy {


  pessoaFisica:PessoaFisica = new PessoaFisica();
  mascaraCPF :string ="000.000.00-00";
  mascaraRG :string ="00.000.000-00";

  constructor (public pessoaFisicaService : PessoaFisicaService , private route: Router){

  }

  ngOnInit(): void {
    
  }

  ngOnDestroy(): void {
    
  }
   

  btnSalvar() {    
    // this.pessoaFisica.cpf = this.pessoaFisica.cpf.replace(/[.-]/g, '')
    // this.pessoaFisica.rg =this.pessoaFisica.rg.replace(/[.-]/g, '');
    this.pessoaFisicaService.addPessoaFisica(this.pessoaFisica).subscribe(
      { 
        next:(response:PessoaFisica)=> {
          console.log(response)
          this.route.navigateByUrl("pessoafisica/lista")
        },      
        error: (error) => {
          console.log(error)
        } 
    });
  }

}
