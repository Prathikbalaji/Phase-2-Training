import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-sampbind',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './sampbind.component.html',
  styleUrl: './sampbind.component.css'
})
export class SampbindComponent {
  fname:string="Payoda"
  lname:string="Organization"
  imageurl:string="/public/gojos.webp"
  value:string = "";

  butn:boolean=false;

  count:number=0;

  countt(){
    this.count ++;
  }

  display(){
    this.butn=true;
    this.fname="Prathik";
    this.lname="Balaji";
  }

  val:string="";

  show(valu:any){
    this.val=valu.target.value;
  }

}
