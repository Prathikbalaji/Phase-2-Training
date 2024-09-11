import { Component } from '@angular/core';
import { ChildTODOComponent } from "../child-todo/child-todo.component";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-parent-todo',
  standalone: true,
  imports: [ChildTODOComponent,CommonModule],
  templateUrl: './parent-todo.component.html',
  styleUrl: './parent-todo.component.css'
})
export class ParentTODOComponent {

  lists : string[] = []

  addtasks(tsk : any){
    this.lists.push(tsk);
  }

}
