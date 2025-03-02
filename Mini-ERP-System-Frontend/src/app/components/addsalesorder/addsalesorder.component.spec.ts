import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddsalesorderComponent } from './addsalesorder.component';

describe('AddsalesorderComponent', () => {
  let component: AddsalesorderComponent;
  let fixture: ComponentFixture<AddsalesorderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddsalesorderComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddsalesorderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
