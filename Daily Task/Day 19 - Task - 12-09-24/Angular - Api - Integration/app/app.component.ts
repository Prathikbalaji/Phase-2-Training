import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { OrganisationListComponent } from './organisation-list/organisation-list.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,OrganisationListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'AngApiInteg';
}
