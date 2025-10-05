import { Component, signal } from '@angular/core';
import { RouterOutlet,RouterLink  } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true, // ✅ This is required
  imports: [RouterOutlet,RouterLink], // ✅ Import RouterOutlet and RouterLink
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Cutting-Down-Project');
}

