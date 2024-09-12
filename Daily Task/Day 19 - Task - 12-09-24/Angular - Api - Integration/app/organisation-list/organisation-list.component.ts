import { Component } from '@angular/core';
import { ApiService } from '../api.service';
import { CommonModule } from '@angular/common';
import { Organisation } from '../Organisation';
import { Router } from '@angular/router';

@Component({
  selector: 'app-organisation-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './organisation-list.component.html',
  styleUrl: './organisation-list.component.css'
})

export class OrganisationListComponent {
  // data :any;
    orgs : Organisation[] = [];

    constructor(private apiser:ApiService,private router:Router)
    {

    }

  /*ngOnInit():void{
       this.apiser.get().subscribe(
         (response) => {
           this.data=response;
           console.log()
         }
       );
    }*/
       ngOnInit(): void {
         this.loadCompanies();
       }
     
       loadCompanies(): void {
         this.apiser.get().subscribe(
           (data) => this.orgs = data,
           (error) => console.error('Error loading companies', error)
         );
       }
     

       viewDetails(id: number): void {
         this.router.navigate(['/Org', id]);
       }
     
       updateCompany(id: number): void {
         this.router.navigate(['/Upd', id]);
       }
       addCompany(): void {
         this.router.navigate(['/add']);
       }
       deleteCompany(id: number): void {
         if (confirm('Are you sure you want to delete this company?')) {
           this.apiser.delOrg(id).subscribe(
             () => {
               console.log('Company deleted successfully');
               this.loadCompanies(); 
             },
             (error) => console.error('Error deleting company', error)
           );
         }
       }
}
