import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllsuppliersComponent } from './allsuppliers.component';

describe('AllsuppliersComponent', () => {
  let component: AllsuppliersComponent;
  let fixture: ComponentFixture<AllsuppliersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AllsuppliersComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AllsuppliersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
