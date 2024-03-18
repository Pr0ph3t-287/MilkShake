import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MilkshakeFormComponent } from './milkshake-form.component';

describe('MilkshakeFormComponent', () => {
  let component: MilkshakeFormComponent;
  let fixture: ComponentFixture<MilkshakeFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MilkshakeFormComponent]
    });
    fixture = TestBed.createComponent(MilkshakeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
