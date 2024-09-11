import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-productlist',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './productlist.component.html',
  styleUrl: './productlist.component.css'
})
export class ProductlistComponent {

  chk : boolean = true
  Val : string = "All"

  prolist : Product[] = [
    {ProID : 1 , ProName : "Dell i5 Laptop", ProPrice : 50000,ProCategory : "Electronics",ProStock : 5,ProImage: "public/dell.jpg" },
    {ProID : 2 , ProName : "Cargo Jeans", ProPrice : 1000,ProCategory : "Clothings",ProStock : 5,ProImage: "public/cargo.jpg"  },
    {ProID: 3, ProName: "Samsung Galaxy S21", ProPrice: 65000, ProCategory: "Electronics", ProStock: 0,ProImage: "public/sams.jpeg" },
    {ProID: 4, ProName: "Iphone 15 pro", ProPrice: 4500, ProCategory: "Electronics", ProStock: 20,ProImage: "public/iphone.jpeg" },
    {ProID: 5, ProName: "Dining Table Set", ProPrice: 25000, ProCategory: "Furniture", ProStock: 3,ProImage: "public/dining.jpeg" }
  ]
  onSubmit(vals : any){
    this.prolist.push(vals.value)
  }
}

class Product{
  ProID : number = 0
  ProName? : string
  ProPrice? : number 
  ProCategory? : string
  ProStock : number = 0
  ProImage? : string
}
