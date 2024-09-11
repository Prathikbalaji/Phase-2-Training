import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildTODOComponent } from './child-todo.component';

describe('ChildTODOComponent', () => {
  let component: ChildTODOComponent;
  let fixture: ComponentFixture<ChildTODOComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChildTODOComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChildTODOComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
