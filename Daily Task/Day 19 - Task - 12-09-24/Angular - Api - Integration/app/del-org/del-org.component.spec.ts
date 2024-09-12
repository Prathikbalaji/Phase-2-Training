import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DelOrgComponent } from './del-org.component';

describe('DelOrgComponent', () => {
  let component: DelOrgComponent;
  let fixture: ComponentFixture<DelOrgComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DelOrgComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DelOrgComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
