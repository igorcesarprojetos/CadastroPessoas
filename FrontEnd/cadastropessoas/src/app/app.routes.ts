import { Routes } from '@angular/router';
import { HomeComponent } from './page/home/home.component';
import { InfoComponent } from './page/info/info.component';
import { UserComponent } from './page/user/user.component';
import { LoginComponent } from './page/login/login.component';
import { CadastroPessoaFisicaComponent } from './page/pessoafisica/cadastropessoafisica/cadastropessoafisica.component';
import { ListaPessoaFisicaComponent } from './page/pessoafisica/listapessoafisica/listapessoafisica.component';
import { ListaPessoaJuridicaComponent } from './page/pessoajuridica/listapessoajuridica/listapessoajuridica.component';
import { CadastroPessoaJuridicaComponent } from './page/pessoajuridica/cadastropessoajuridica/cadastropessoajuridica.component';
import { AuthGuardService } from './services/shared/authguard.service';

export const routes: Routes = [  
  { path:"login" , component:LoginComponent },
  { path:"" , redirectTo:"home",pathMatch:'full' },
  { path:"home" , component:HomeComponent, canActivate:[AuthGuardService] },
  { path:"info" , component:InfoComponent, canActivate:[AuthGuardService] },  
  { path:"user" , component:UserComponent, canActivate:[AuthGuardService] },
  { path:"pessoafisica/lista" , component:ListaPessoaFisicaComponent , canActivate:[AuthGuardService] },
  { path:"pessoafisica/cadastro" , component:CadastroPessoaFisicaComponent , canActivate:[AuthGuardService] },
  { path:"pessoajuridica/lista" , component:ListaPessoaJuridicaComponent , canActivate:[AuthGuardService] },
  { path:"pessoajuridica/cadastro" , component:CadastroPessoaJuridicaComponent , canActivate:[AuthGuardService] },
];
