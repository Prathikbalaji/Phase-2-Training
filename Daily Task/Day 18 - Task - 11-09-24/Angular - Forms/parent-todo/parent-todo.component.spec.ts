import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ParentTODOComponent } from './parent-todo.component';

describe('ParentTODOComponent', () => {
  let component: ParentTODOComponent;
  let fixture: ComponentFixture<ParentTODOComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ParentTODOComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ParentTODOComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
