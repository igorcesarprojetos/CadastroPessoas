import { Component } from '@angular/core';
import {MatCardModule} from '@angular/material/card';

const modules = [MatCardModule]

@Component({
  selector: 'app-info',  
  imports: [modules],
  templateUrl: './info.component.html',
  styleUrl: './info.component.css'
})
export class InfoComponent {

}
