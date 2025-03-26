import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';

const modules = [MatCardModule]

@Component({
  selector: 'app-home',
  imports: [MatCardModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
