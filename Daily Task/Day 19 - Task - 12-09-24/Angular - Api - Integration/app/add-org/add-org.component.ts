import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { Route, Router } from '@angular/router';
import { Organisation } from '../Organisation';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-add-org',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-org.component.html',
  styleUrl: './add-org.component.css'
})
export class AddOrgComponent {

  org : Organisation = {orgId:0,orgName:''};

  constructor(private apiser : ApiService,private router:Router){

  }

  onSubmit() : void{
    this.apiser.postOrg(this.org).subscribe(
      (response)=>{
        console.log('Added!',response);
        this.router.navigate(['/']);
      }
    )
  };



}
