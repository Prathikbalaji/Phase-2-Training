import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output, output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-child-todo',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './child-todo.component.html',
  styleUrl: './child-todo.component.css'
})
export class ChildTODOComponent {

  val : string =""
  @Output() added :EventEmitter<string>= new EventEmitter();

  get(str : any){
    this.added.emit(str);
  }

}
