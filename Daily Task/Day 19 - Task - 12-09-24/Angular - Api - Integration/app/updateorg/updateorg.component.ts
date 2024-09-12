import { Component } from '@angular/core';
import { Organisation } from '../Organisation';
import { ApiService } from '../api.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-updateorg',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './updateorg.component.html',
  styleUrl: './updateorg.component.css'
})
export class UpdateorgComponent {
  org : Organisation ={orgId:0,orgName:""}

  constructor(private apiser : ApiService,private route:ActivatedRoute,private router : Router){

  }

  ngOnInit():void{
    const id = +this.route.snapshot.params['id'];
    this.apiser.getbyid(id).subscribe(
      (response) => {
        this.org = response
      }
    )
  }

  onSubmit() : void{
    this.apiser.updOrg(this.org.orgId,this.org).subscribe(
      (response)=>{
        console.log('Updated!',response);
        this.router.navigate(['/']);
      }
    )
  };

}
