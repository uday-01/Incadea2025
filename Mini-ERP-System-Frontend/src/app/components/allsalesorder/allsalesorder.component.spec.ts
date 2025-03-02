import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllsalesorderComponent } from './allsalesorder.component';

describe('AllsalesorderComponent', () => {
  let component: AllsalesorderComponent;
  let fixture: ComponentFixture<AllsalesorderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AllsalesorderComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AllsalesorderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
