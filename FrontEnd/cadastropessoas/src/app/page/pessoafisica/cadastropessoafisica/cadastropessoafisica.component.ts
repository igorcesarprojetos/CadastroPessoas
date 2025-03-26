import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { PessoaFisica } from '../../../models/pessoafisica';
import { PessoaFisicaService } from '../../../services/pessoafisica.service';

const modules = [MatCardModule,MatFormFieldModule,MatInputModule, FormsModule]

@Component({
  selector: 'app-cadastropessoafisica',
  imports: [modules],
  templateUrl: './cadastropessoafisica.component.html',
  styleUrl: './cadastropessoafisica.component.css'
})
export class CadastroPessoaFisicaComponent implements OnInit, OnDestroy {


  pessoaFisica:PessoaFisica = new PessoaFisica();

  constructor (public pessoaFisicaService : PessoaFisicaService){

  }

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  ngOnDestroy(): void {
    throw new Error('Method not implemented.');
  }
   

  btnSalvar() {
    this.pessoaFisicaService.addPessoaFisica(this.pessoaFisica).subscribe();
  }

}
