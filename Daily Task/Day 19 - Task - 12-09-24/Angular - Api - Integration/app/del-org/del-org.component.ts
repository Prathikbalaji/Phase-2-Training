import { Component } from '@angular/core';
import { Organisation } from '../Organisation';
import { ApiService } from '../api.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-del-org',
  standalone: true,
  imports: [],
  templateUrl: './del-org.component.html',
  styleUrl: './del-org.component.css'
})
export class DelOrgComponent {

  constructor(private apiser : ApiService,private route:ActivatedRoute){

  }

  ngOnInit():void{
    const id = +this.route.snapshot.params['id'];
    this.apiser.delOrg(id).subscribe(
    )
  }
}
