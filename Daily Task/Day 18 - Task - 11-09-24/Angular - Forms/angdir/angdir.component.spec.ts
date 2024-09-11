import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AngdirComponent } from './angdir.component';

describe('AngdirComponent', () => {
  let component: AngdirComponent;
  let fixture: ComponentFixture<AngdirComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AngdirComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AngdirComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
