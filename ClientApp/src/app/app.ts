import { Component } from '@angular/core';
import { Movimentos } from './components/movimentos/movimentos';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [Movimentos],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {}