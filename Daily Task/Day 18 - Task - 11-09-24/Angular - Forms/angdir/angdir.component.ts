import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-angdir',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './angdir.component.html',
  styleUrl: './angdir.component.css'
})
export class AngdirComponent {

  num:number=1

  isLog : boolean = false

  login(){
    this.isLog = !this.isLog;
  }

}
