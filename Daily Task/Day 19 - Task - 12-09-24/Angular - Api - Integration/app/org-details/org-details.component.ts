import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { ActivatedRoute } from '@angular/router';
import { Organisation } from '../Organisation';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-org-details',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './org-details.component.html',
  styleUrl: './org-details.component.css'
})
export class OrgDetailsComponent {
  org : Organisation | undefined

  constructor(private apiser : ApiService,private route:ActivatedRoute){

  }

  ngOnInit():void{
    const id = +this.route.snapshot.params['id'];
    this.apiser.getbyid(id).subscribe(
      (response) => {
        this.org = response
      }
    )
  }
}
