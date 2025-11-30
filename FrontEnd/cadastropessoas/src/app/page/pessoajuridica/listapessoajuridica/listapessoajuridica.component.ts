import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { NgxMaskPipe} from 'ngx-mask';
import { pipe } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MessageService } from '../../../services/message/message.service';
import { PessoaJuridica } from '../../../models/pessoajuridica';
import { PessoaJuridicaService } from '../../../services/pessoajuridica.service';


const modules = [MatCardModule,MatFormFieldModule,MatInputModule, MatTableModule, MatIconModule, MatButtonModule]

@Component({
  selector: 'app-listapessoajuridica',
  imports: [modules,NgxMaskPipe],
  templateUrl: './listapessoajuridica.component.html',
  styleUrl: './listapessoajuridica.component.css'
})
export class ListaPessoaJuridicaComponent {

   dataSource: PessoaJuridica[]=[];  

  constructor(private pessoaJuridicaService:PessoaJuridicaService, private router:Router, private messageService: MessageService)
  {
    
  }

    ngOnInit(): void {
      this.dataSource=[]    
      this.loadGridPJ()
    }
  
    btnDeletar(pessoaJuridica: PessoaJuridica) {
      this.pessoaJuridicaService.deletePessoaJuridica(pessoaJuridica).subscribe({
          next: (response) => {
            this.messageService.showSuccess(`Sucesso:${response}`);
            // Lógica para sucesso
          },
          error: (error) => {
            this.messageService.showError(`Erro:${error}`);          
            // Lógica para erro
          },
          complete: () => {
            this.messageService.showSuccess('Operação completada');
            // Lógica que sempre executa (opcional)
          }
        });
    }
  
    btnSearch(pessoaJuridica: PessoaJuridica) {
      if(pessoaJuridica!=null && pessoaJuridica.Id>0){
  
        this.pessoaJuridicaService.getById(pessoaJuridica.Id).subscribe({
          next: (response:PessoaJuridica) => {
           this.router.navigate([`pessoafisica/cadastro/${response.Id}`]) 
            // Lógica para sucesso
          },
          error: (error) => {
            this.messageService.showError(`Erro:${error}`);          
            // Lógica para erro
          },
          
        });  
      }
    }
  
    loadGridPJ(){
  
       return this.pessoaJuridicaService.getAll().subscribe({
          next: (response:PessoaJuridica[]) => {
           this.dataSource=response
            // Lógica para sucesso
          },
          error: (error) => {
            this.messageService.showError(`Erro:${error}`);          
            // Lógica para erro
          },
          
        });
      
    }
  
    AddPJ() {
      this.router.navigate(["pessoajuridica/cadastro"]) 
    }

}
